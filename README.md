# F# and 3D composition


In his article [*composing christmas*](http://tomasp.net/blog/2014/composing-christmas/), [@tomaspetricek](http://tomasp.net/) gives a really nice example about what composition really is.

He developed a library called [Functional3D](https://github.com/tpetricek/Documents/blob/master/Talks%202014/DSL%20%28Dojo%29/dojo/Functional3D/functional3d.fs) providing the ability to create/manipulate 3D objects.

`Fun.cone`, `Fun.cylinder`, `Fun.sphere` create 3D volumes that you can assemble altogether with transformations like `Fun.translate`, `Fun.rotate` ...


All the hard part of creating a 3D scene is hidden in this library. You end up creating a 4 spike stars like this:

```fsharp
let spike r =
  Fun.cone
  |> Fun.scale (0.5, 0.5, 2.0)
  |> Fun.translate (0.0, 0.0, -1.0)
  |> Fun.rotate (r, 0.0, 0.0)

let star =
  [ for r in 0.0 .. 90.0 .. 270.0 -> spike r ]
  |> List.reduce ($)
```

Moreover the library generate a *backend* for F# Interactive. So every time you create an object, it will be rendered in the 3D scene.

So if you load the above code in the REPL and write:
```bash
> star;;
```

a window will open and will display your star.

## Build

- Simply build Exercism.sln in Visual Studio 2013, Visual Studio 2015, Mono Develop, or Xamarin Studio. You can also use the FAKE script:

  * Windows: Run *scripts\build.cmd*
    * [![AppVeyor build status](https://ci.appveyor.com/api/projects/status/3a6ehb7nr95lts5s?svg=true)](https://ci.appveyor.com/project/bcachet/fun3d)
  * Mono: Run *scripts\build.sh*
    * [![Travis build status](https://travis-ci.org/bcachet/fun3d.svg)](https://travis-ci.org/bcachet/fun3d)
