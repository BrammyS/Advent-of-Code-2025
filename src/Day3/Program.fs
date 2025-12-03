open System.Diagnostics
open System.IO
open Day3.Logic

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")

// Warm up
for i in 0 .. 50 do
    calculateJoltage(lines, 2) |> ignore

let sw1 = Stopwatch.StartNew()
let sumPart1 = calculateJoltage(lines, 2)
sw1.Stop()
printfn $"Elapsed: %A{sw1.Elapsed.TotalMilliseconds} ms"
printfn $"Part 1 sum: {sumPart1}"

let sw2 = Stopwatch.StartNew()
let sumPart2 = calculateJoltage(lines, 12)
sw2.Stop()
printfn $"Elapsed: %A{sw2.Elapsed.TotalMilliseconds} ms"
printfn $"Part 2 sum: {sumPart2}"
