# F# CheatSheet

```bash
# Create new project
dotnet new console -n test1 -lang f#
```

## Tweets

- [Tipos no F#](https://twitter.com/LucasTeles42/status/1349739654229024768)
- [Is working with Excel files supposed to be this easy? #fsharp #dotnet](https://twitter.com/zaid_ajaj/status/1365124291965157380)
- [DSL design comparation](https://twitter.com/AndrzejWasowski/status/1365262125384531969/photo/1)
- [3D vector operations](https://twitter.com/EdgarSanchez/status/1369736201998131202)
- [Feliz - trick to import CSS into F# views](https://twitter.com/alfonsogcnunez/status/1370277006705782786)
- [Using ComputeSharp from F#](https://twitter.com/SergioPedri/status/1370395892478541828)
- [Photino.NET is an Electron for .NET but smaller?](https://twitter.com/sergey_tihon/status/1369391535905718274)
- [Active patterns](https://twitter.com/LucasTeles42/status/1372924075287400452)
- [Decimal arithmetic](https://twitter.com/EdgarSanchez/status/1375819622310674433/photo/1)
- [AST for F#](https://twitter.com/nansdotio/status/1375912690342760451)
- [F# pipes](https://twitter.com/rosalogia/status/1376085738580811776)
- [OR patterns](https://twitter.com/deviousasti/status/1376574074017607681)
- [Use FelizEngine instead of Razor on AspNetCore.Mvc](https://twitter.com/zaid_ajaj/status/1378010911722643467/photo/1)
- [Recursive function calls](https://twitter.com/buhakmeh/status/1379484033277698048)
- [Sutil with Tailwind CSS](https://twitter.com/DaveDawkins/status/1383911451958538240)
- [Match conditions in F#](https://twitter.com/badamczewski01/status/1385183920388460544) Obs.: Labels are wrong
- [Bitcoin coding](https://twitter.com/Odytrice/status/1385886516627525633)
- [F# lambdas are awesome 1](https://twitter.com/badamczewski01/status/1386952998652420097)
  - [F# lambdas are awesome 2](https://twitter.com/badamczewski01/status/1386968259132538880)
    - [F# lambdas are awesome 3](https://twitter.com/badamczewski01/status/1387002158411812865)
      - [F# lambdas are awesome 4](https://twitter.com/badamczewski01/status/1387373591050788866)
        - [F# lambdas are awesome 5](https://twitter.com/badamczewski01/status/1387664551374639107)
- [How to use F# to create shell scripts?](https://twitter.com/adelarsq/status/1390459435194241025)

## Samples

- [crdt-examples](https://github.com/Horusiath/crdt-examples) - implementations of various CRDTs

### Codes

```fsharp
// Functions
let linear x = 2.0 * x
let quadratic x = x ** 2

// read a line on console
open System
let line = Console.ReadLine()
printfn "Read line %s" line

// Defining a list
let lista = [
    2
    3 ]

// List just par numbers from a descrecent list
[9 .. -1 .. 1] |> List.filter (fun x -> x % 2 = 0)

// Calling an API using the F# Data Http utility:
// Source: https://stackoverflow.com/questions/62408621/f-with-http-fs-not-able-to-execute-graphql-apis
Http.RequestString
  ( "https://swapi.graph.cool", 
    httpMethod="POST", headers=[ HttpRequestHeaders.ContentType("application/json") ],
    body=TextRequest("{\"query\": \"{ allFilms { title } }\"}") 
```

## printfn

```fsharp
// hello world
open System
[<EntryPoint>]
let main argv =
    let square x = x * x
    let squared = List.map square [1;2;3;5;7]
    printfn "%A" squared
    0 // return an integer exit code

Array.map (fun x -> -x) [|0..9|];;
// val it : int [] = [|0; -1; -2; -3; -4; -5; -6; -7; -8; -9|]

List.map (fun x -> -x) [0..9];;
// val it : int list = [0; -1; -2; -3; -4; -5; -6; -7; -8; -9]

Seq.map (fun x -> -x)  { 0..9 };;
// val it : seq<int> = seq [0; -1; -2; -3; ...]
```

| Format | Type             |
| ------ | ---------------- |
| %s 	   | string           |
| %i 	   | integer          |
| %u 	   | unsigned integer |
| %f 	   | float            |
| %b 	   | boolean          |
| %O 	   | other objects    |
| %o 	   | octal            |
| %x 	   | lowercase hex    |
| %X 	   | uppercase hex    |
| %A 	   | native F# types  |


## functions

```fsharp
open System
let ``print emoji  🐣`` =
    printfn "🐣"
``print emoji  🐣``
```

## F# Types with .NET 5

[Source](https://github.com/dotnet/runtime/issues/29812)

Just as a quick update, various things do work.

This example now works in .NET 5:

```fsharp
open System
open System.Text.Json


[<EntryPoint>]
let main _argv =

    let m1 = Map.empty<string, string> |> Map.add "answer" "42"
    let json1 = JsonSerializer.Serialize(m1)
    printfn "JSON1 %s" json1
    
    let m2 = Map.empty<string, Version> |> Map.add "version" (Version("10.0.1.1"))
    let json2 = JsonSerializer.Serialize(m2)
    printfn "JSON2 %s" json2

    0
```

F# records and anonymous records now appear to work (nested records example):

```fsharp
open System
open System.Text.Json

type Person = { Name: string; Age: int }
type Gaggle = { People: Person list; Name: string }

[<EntryPoint>]
let main _argv =

    let r1 =
        {
            People =
                [ { Name = "Phillip"; Age = Int32.MaxValue }
                  { Name = "Ryan Nowak"; Age = Int32.MinValue } ]
            Name = "Meme team"
        }

    let r2 =
        {|
            r1 with
                FavoriteMusic = "Dan Roth's Banjo Bonanza"
        |}

    printfn $"{JsonSerializer.Serialize r1}"
    printfn $"{JsonSerializer.Serialize r2}"

    0
```

But DUs are still missing. FSharp.SystemTextJson is still the way to serialize F# union types.

## C# Interop

```fsharp
// ResizeArray is the name of the #CSharp generic list class in #FSharp, so you can do:
let csList = ResizeArray  [| rec01; rec02; rec03 |] 
```

## Using `use`

```fsharp
// Fonte: https://twitter.com/LucasTeles42/status/1317945856641978375
open System

let main =
  use recurso = {
    new IDisposable with
      member this.Dispose() =
        printfn "liberando recurso..."
  }
  printfn "acabou..."
```

## Using Feliz

- [Twitter - Sample Feliz](https://twitter.com/theimowski/status/1331355724866334722)

## List Comprehension

```fsharp
// Source https://twitter.com/LucasTeles42/status/1335981686794936320
> let items x = [
-     1
-     2
-     if x then 3
-
-     let n = 10
-     yield! [4..n]
-
-     n + 1
-
-     for numero = n + 2 to n * 2 do
-         numero
- ];;
val items : x:bool -> int list

> printfn "%A" (items true);;
[1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20]
val it : unit = ()
```

## Sync/Async

```fsharp
let work = async { do printfn "Hi" }

work
|> Async.RunSynchronously
```

## [FSI (F# Repl)](https://docs.microsoft.com/pt-br/dotnet/fsharp/tutorials/fsharp-interactive/)

Started with:

```
dotnet fsi
```

Options:

- `#help` - Exibe informações sobre as diretivas disponíveis.
- `#I` - Especifica um caminho de pesquisa de assembly entre aspas.
- `#load` - Lê um arquivo de origem, compila e o executa.
- `#quit` - Finaliza uma sessão do F# interativo.
- `#r` - Faz referência a um assembly.
- `#time ["on"|"off"]` - Por si só, #time alterna se deve exibir informações sobre o desempenho. Quando habilitado, o F# interativo mede informações em tempo real, em tempo de CPU e de coleta de lixo de cada seção do código que é interpretado e executado.

References:

- https://docs.microsoft.com/pt-br/dotnet/fsharp/language-reference/fsharp-interactive-options

