module HelloWorld

// Color Fountain by Erik Novales: https://github.com/enovales

open Fable.Core
open Fable.Core.JsInterop
open Browser.Types
open Browser

let canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
canvas.width <- 1000.
canvas.height <- 800.
let ctx = canvas.getContext_2d()

let rng (): float = JS.Math.random()

let particleLimit = 200

type Particle = {
    x: double
    y: double
    xvel: double
    yvel: double
    c: (int * int * int)
    rot: double
    rotVel: double
}
with
    override this.ToString() =
        let (r,g,b) = this.c
        sprintf "Particle(x = %O, y = %O, xvel = %O, yvel = %O, c = (%O, %O, %O))"
            this.x this.y this.xvel this.yvel r g b


let updateParticle(dt: double)(p: Particle) =
    {
        p with
            x = p.x + p.xvel * dt
            y = p.y + p.yvel * dt
            yvel = p.yvel + 1. * dt
            rot = (p.rot + p.rotVel * dt) % (2. * 3.14159)
    }

let refillParticles(p: Particle array, dt: double) =
    let stillValid =
        p |> Array.filter(fun pt -> (pt.y < 1000.))
    //System.Console.WriteLine("stillValid.Length = " + stillValid.Length.ToString())
    let updatedPos =
        stillValid
        |> Array.map(updateParticle(dt))

    //System.Console.WriteLine("updatedPos = " + updatedPos |> Array.map(fun p -> p.ToString()).ToString())
    let toCreate = particleLimit - stillValid.Length
    //System.Console.WriteLine("going to create " + toCreate.ToString() + " particles")
    let newParticles =
        seq {
            for i in 0..toCreate do
                yield {
                    Particle.x = 200.
                    y = 300.
                    xvel = (rng() - 0.5) * (rng() * 30.)
                    yvel = -(rng() * 25.)
                    c = (int (rng() * 255.), int (rng() * 255.), int (rng() * 255.))
                    rot = (rng() * 2. * 3.14159)
                    rotVel = (rng() * 1.5)
                }
        }
        |> Seq.toArray

    updatedPos |> Array.append(newParticles)

let mutable particles = [||]
let timestep = 0.8

let rec loop last t =
    // Comment out this line to make sure the animation runs
    // with same speed on different frame rates
    let timestep = (t - last) / 20.
    particles <- refillParticles(particles, timestep)

    ctx.clearRect(0., 0., 10000., 10000.)
    let drawParticle(p: Particle) =
        let (r,g,b) = p.c
        let fs = "rgb(" + r.ToString() + ", " + g.ToString() + ", " + b.ToString() + ")"
        ctx.fillStyle <- !^fs

        let x1 = (p.x - 5.)
        let x2 = (p.x + 5.)
        let y1 = (p.y - 5.)
        let y2 = (p.y + 5.)

        // let x1 = (p.x - (10. * System.Math.Cos(p.rot)))
        // let x2 = (p.x + (10. * System.Math.Cos(p.rot)))
        // let y1 = (p.y - (10. * System.Math.Sin(p.rot)))
        // let y2 = (p.y + (10. * System.Math.Sin(p.rot)))

        // ctx.fillRect(x1, y1, 10., 10.)
        ctx.beginPath()
        ctx.moveTo(x1, y1)
        ctx.lineTo(x2, y1)
        ctx.lineTo(x2, y2)
        ctx.lineTo(x1, y2)
        ctx.lineTo(x1, y1)
        ctx.closePath()
        ctx.fill()

    particles
    |> Array.iter drawParticle

    window.requestAnimationFrame(loop t) |> ignore

// start the loop
loop 0. 0.