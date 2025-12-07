open System.Diagnostics
open System.IO
open Day7.Logic

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")

// Warm up
for i in 0..50 do
    sumBeams lines |> ignore

let sw = Stopwatch.StartNew()
let sum = sumBeams lines
sw.Stop()
printfn $"Part 1 & 2 Sum: {sum}"
printfn $"Part 1 & 2 Elapsed in: %A{sw.Elapsed.TotalMilliseconds} ms"
