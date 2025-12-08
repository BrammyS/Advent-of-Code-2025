open System.Diagnostics
open System.IO
open Day8.Logic

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")

// Warm up
for i in 0..5 do
    getSortedPoints lines |> ignore

let sw1 = Stopwatch.StartNew()
let part1 = calculatePart1 lines 1000
sw1.Stop()
printfn $"Part 1 Sum: {part1}"
printfn $"Part 1 Elapsed in: %A{sw1.Elapsed.TotalMilliseconds} ms"
