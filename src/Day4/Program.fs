open System.Diagnostics
open System.IO
open Day4.Part1
open Day4.Part2

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")

// Warm up
for i in 0 .. 50 do
    sumAccessibleRollsOfPaperPart1(lines, 4, 1) |> ignore

let sw1 = Stopwatch.StartNew()
let sumPart1 = sumAccessibleRollsOfPaperPart1(lines, 4, 1)
sw1.Stop()
printfn $"Elapsed: %A{sw1.Elapsed.TotalMilliseconds} ms"
printfn $"Part 1 sum: {sumPart1}"

let sw2 = Stopwatch.StartNew()
let sumPart2 = sumAccessibleRollsOfPaperPart2(lines, 4, 1)
sw2.Stop()
printfn $"Elapsed: %A{sw2.Elapsed.TotalMilliseconds} ms"
printfn $"Part 2 sum: {sumPart2}"