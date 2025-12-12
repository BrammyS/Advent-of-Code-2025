open System.Diagnostics
open System.IO
open Day12.Logic

let text = File.ReadAllText("Input.txt")

// Warm up
for i in 0..500 do
    solvePart1 text |> ignore

let sw1 = Stopwatch.StartNew()
let part1 = solvePart1 text
sw1.Stop()
printfn $"Part 1 Sum: {part1}"
printfn $"Part 1 Elapsed in: %A{sw1.Elapsed.TotalMilliseconds} ms"
