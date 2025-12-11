open System.Diagnostics
open System.IO
open Day11.Logic

let lines = File.ReadAllLines("Input.txt")

// Warm up
for i in 0..50 do
    solvePart1 lines |> ignore

let sw1 = Stopwatch.StartNew()
let part1 = solvePart1 lines
sw1.Stop()
printfn $"Part 1 Sum: {part1}"
printfn $"Part 1 Elapsed in: %A{sw1.Elapsed.TotalMilliseconds} ms"

