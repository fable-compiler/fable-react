module TodoMVC

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser
open Browser.Types

// Director is a router. Routing is the process of determining
// what code to run when a URL is requested.
let Router(routes: obj): obj =
    importDefault "./director.js"

module Util =
    let load<'T> key: 'T option =
        window.localStorage.getItem(key)
        |> Option.ofObj
        |> Option.map (fun json -> !!JS.JSON.parse(json))

    let save key (data: 'T) =
        window.localStorage.setItem(key, JS.JSON.stringify data)

type Todo =
    { id: Guid
      title: string
      completed: bool }

type TodoModel(key) =
    member val key = key
    member val todos: Todo[] = defaultArg (Util.load key) [||] with get, set
    member val onChanges: (unit->unit) [] = [||] with get, set

    member this.subscribe(onChange) =
        this.onChanges <- [|onChange|]

    member this.inform() =
        Util.save this.key this.todos
        this.onChanges |> Seq.iter (fun cb -> cb())

    member this.addTodo(title) =
        this.todos <-
            [|{ id=Guid.NewGuid(); title=title; completed=false }|]
            |> Array.append this.todos
        this.inform()

    member this.toggleAll(checked') =
        this.todos <- this.todos |> Array.map (fun todo ->
            { todo with completed = checked' })
        this.inform()

    member this.toggle(todoToToggle) =
        this.todos <- this.todos |> Array.map (fun todo ->
            if todo.id <> todoToToggle.id then todo
            else { todo with completed = (not todo.completed) })
        this.inform()

    member this.destroy(todoToDestroy) =
        this.todos <- this.todos |> Array.filter (fun todo ->
            todo.id <> todoToDestroy.id)
        this.inform()

    member this.save(todoToSave, text) =
        this.todos <- this.todos |> Array.map (fun todo ->
            if todo.id <> todoToSave.id then todo
            else { todo with title = text })
        this.inform()

    member this.clearCompleted() =
        this.todos <- this.todos |> Array.filter (fun todo ->
            not todo.completed)
        this.inform()

open Fable.React
open Fable.React.Props

let [<Literal>] ESCAPE_KEY = 27.
let [<Literal>] ENTER_KEY = 13.
let [<Literal>] ALL_TODOS = "all"
let [<Literal>] ACTIVE_TODOS = "active"
let [<Literal>] COMPLETED_TODOS = "completed"

let TodoItemLabelStyleContext = createContext (fun s -> str s)

type TodoComponent =
 [<ReactComponent>]
  static member Item(key: Guid,
                     todo: Todo,
                     editing: bool,
                     onSave: string->unit,
                     onEdit: unit->unit,
                     onDestroy: unit->unit,
                     onCancel: unit->unit,
                     onToggle: unit->unit) =
    let state = Hooks.useState(todo.title)
    let editField: IRefHook<Element option> = Hooks.useRef None
    let labelStyle = Hooks.useContext TodoItemLabelStyleContext

    Hooks.useEffect((fun () ->
        let editField = editField.current.Value :?> HTMLInputElement
        editField.focus()
        editField.setSelectionRange(editField.value.Length, editField.value.Length)
    ), [|editing|])

    let handleSubmit _ =
        match state.current.Trim() with
        | value when value.Length > 0 ->
            onSave(value)
            state.update value
        | _ ->
            onDestroy()

    let handleEdit _ =
        onEdit()
        state.update todo.title

    let handleKeyDown (ev: KeyboardEvent) =
        match ev.which with
        | ESCAPE_KEY ->
            state.update todo.title
            onCancel()
        | ENTER_KEY ->
            handleSubmit(ev)
        | _ -> ()

    let handleChange (ev: Event) =
        if editing then
            state.update ev.Value

    li [ classList ["completed", todo.completed
                    "editing", editing] ] [
        div [ Class "view" ] [
            input [
                Class "toggle"
                Type "checkbox"
                Checked todo.completed
                OnChange (fun _ -> onToggle())
            ]
            label [ OnDoubleClick handleEdit ]
                  [ labelStyle todo.title ]
            button [
                Class "destroy"
                OnClick (fun _ -> onDestroy()) ] [ ]
        ]
        input [
            Class "edit"
            RefValue editField
            Value state.current
            OnBlur handleSubmit
            OnChange handleChange
            OnKeyDown handleKeyDown
        ]
    ]

  [<ReactComponent>]
  static member Footer (count: int,
                        completedCount: int,
                        onClearCompleted: unit->unit,
                        nowShowing: string) =
    let activeTodoWord =
        "item" + (if count = 1 then "" else "s")
    let clearButton =
        if completedCount > 0 then
            button [
                Class "clear-completed"
                OnClick (fun _ -> onClearCompleted())
            ] [ str "Clear completed" ]
        else nothing
    let filter href name category =
        li [] [
            a [ Href href
                classList ["selected", (nowShowing = category)] ]
              [ str name ] ]
    footer [ Class "footer" ] [
        span [ Class "todo-count" ] [
            strong [] [ count |> string |> str ]
            str (" " + activeTodoWord + " left")
        ]
        ul [ Class "filters" ] [
            filter "#/" "All" ALL_TODOS
            str " "
            filter "#/active" "Active" ACTIVE_TODOS
            str " "
            filter "#/completed" "Completed" COMPLETED_TODOS
            clearButton
        ]
    ]

[<ReactComponent(exportDefault=true)>]
let TodoApp (model: TodoModel) =
    let state = Hooks.useState {| nowShowing = ALL_TODOS
                                  editing = Option<Guid>.None
                                  newTodo = "" |}
    Hooks.useEffect(fun () ->
        let nowShowing category () =
            state.update(fun s -> {| s with nowShowing = category |})
        let router =
            Router(createObj [
                    "/" ==> nowShowing ALL_TODOS
                    "/active" ==> nowShowing ACTIVE_TODOS
                    "/completed" ==> nowShowing COMPLETED_TODOS
            ])
        router?init("/")
    , [||])

    let handleChange (ev: Event) =
        // Save the the value, because React will recycle the event instance
        // by the time the callback is called
        let newTodo = ev.Value
        state.update(fun s -> {| s with newTodo = newTodo |})

    let handleNewTodoKeyDown (ev: KeyboardEvent) =
        if ev.keyCode = ENTER_KEY then
            ev.preventDefault()
            let v = state.current.newTodo.Trim()
            if v.Length > 0 then
                model.addTodo(v)
                state.update(fun s -> {| s with newTodo = "" |})

    let toggleAll (ev: Event) =
        model.toggleAll(ev.Checked)

    let toggle (todoToToggle) =
        model.toggle(todoToToggle)

    let destroy (todo) =
        model.destroy(todo)

    let edit (todo: Todo) =
        state.update(fun s -> {| s with editing = Some todo.id |})

    let save (todoToSave, text) =
        model.save(todoToSave, text)
        state.update(fun s -> {| s with editing = None |})

    let cancel () =
        state.update(fun s -> {| s with editing = None |})

    let clearCompleted () =
        model.clearCompleted()

    let todos = model.todos
    let todoItems =
        todos
        |> Seq.filter (fun todo ->
            match state.current.nowShowing with
            | ACTIVE_TODOS -> not todo.completed
            | COMPLETED_TODOS -> todo.completed
            | _ -> true)
        |> Seq.map (fun todo ->
            TodoComponent.Item(
                key = todo.id,
                todo = todo,
                editing = (match state.current.editing with
                           | Some editing -> editing = todo.id
                           | None -> false),
                onSave = (fun text -> save(todo, string text)),
                onEdit = (fun _ -> edit(todo)),
                onDestroy = (fun _ -> destroy(todo)),
                onCancel = (fun _ -> cancel()),
                onToggle = (fun _ -> toggle(todo)))
        ) |> Seq.toList
    let activeTodoCount =
        todos |> Array.fold (fun accum todo ->
            if todo.completed then accum else accum + 1
        ) 0
    let completedCount =
        todos.Length - activeTodoCount
    let footer =
        if activeTodoCount > 0 || completedCount > 0 then
            TodoComponent.Footer(
                activeTodoCount,
                completedCount,
                clearCompleted,
                state.current.nowShowing)
        else nothing
    let main =
        if todos.Length > 0 then
            section [ Class "main" ] [
                input [
                    Class "toggle-all"
                    Type "checkbox"
                    OnChange toggleAll
                    Checked (activeTodoCount = 0)
                ]
                ul [ Class "todo-list" ] todoItems
            ]
        else nothing
    div [] [
        header [ Class "header" ] [
            h1 [] [ str "todos" ]
            input [
                Class "new-todo"
                Placeholder "What needs to be done?"
                Value state.current.newTodo
                OnKeyDown handleNewTodoKeyDown
                OnChange handleChange
                AutoFocus true
            ]
        ]
        contextProvider TodoItemLabelStyleContext (fun title ->
            str title // strong [] [str title]
        ) [main]
        footer
    ]

let model = TodoModel("react-todos")

let render() =
    ReactDom.render(
        TodoApp model,
        document.getElementsByClassName("todoapp").[0])

model.subscribe(render)
render()