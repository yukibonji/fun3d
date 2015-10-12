#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

// Restore Packages
RestorePackages()

let resultsDir = "Binaries"

Target "Clean" (fun _ ->
    DeleteDirs [resultsDir]
)

Target "Build" (fun _ ->
    !! "/**/*.*proj"
    |> MSBuildRelease resultsDir "Build"
    |> Log "Build-Output: "
)

"Clean"
    ==> "Build"

RunTargetOrDefault "Build"
