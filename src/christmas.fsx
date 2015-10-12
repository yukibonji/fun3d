#if INTERACTIVE
#load "functional3d.fs"
#endif

open System.Drawing
open Functional3D

/// Creates a single spike, starting from the
/// center of the world, rotated by `r` degrees
let spike r =
  Fun.cone
  |> Fun.scale (0.5, 0.5, 2.0)
  |> Fun.translate (0.0, 0.0, -1.0)
  |> Fun.rotate (r, 0.0, 0.0)

/// Represents a star with 12 spikes
let star =
  [ for r in 0.0 .. 30.0 .. 330.0 -> spike r ]
  |> List.reduce ($)

/// Creates a glowing star with changing color
let glowingStar time =
  // Values varying between -96 .. +96 and 0.7 .. 1.3
  let phase = sin (time / 20.0) * 96.0
  let size = 1.0 + (0.3 * sin (time / 20.0))
  let clr = Color.FromArgb(255, 159+int phase, 64)

  // Change the color and scaling of a star
  star
  |> Fun.color clr
  |> Fun.scale (1.0, size, size)
  |> Fun.rotate (90.0, 90.0, 90.0)
