// Source: https://twitter.com/LucasTeles42/status/1317945856641978375
open System

let main =
  use recurso = {
    new IDisposable with
      member this.Dispose() =
        printfn "liberando recurso..."
  }
  printfn "acabou..."
