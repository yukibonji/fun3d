#if INTERACTIVE
#load "christmas.fsx"
#endif

open Christmas
open Functional3D
open System.Drawing
open System.Threading

[<EntryPoint>]
let main argv =
  let gs = Fun.animate glowingStar
  Async.Sleep(3*1000) |> Async.RunSynchronously
  gs.Cancel true
  0
