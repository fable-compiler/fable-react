namespace Fable.React

type [<AllowNullLiteral>] ReactElement =
    interface end

type ReactElementType =
    interface end

type ReactElementType<'props> =
    inherit ReactElementType

type IRefValue<'T> =
    abstract current: 'T with get, set

type IContext<'T> =
    interface end

type ISSRContext<'T> =
    inherit IContext<'T>
    abstract DefaultValue: 'T
