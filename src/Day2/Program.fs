module Program

open System.IO
open System.Diagnostics
open Day2.Part1
open Day2.Part2


printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")
let ranges = lines[0].Split ','

printfn "Part 1: Sum of invalid IDs"
printfn "Calculating total sum of invalid IDs..."
let sw = Stopwatch.StartNew()
let sum = sumInvalidIdsPart1 ranges
sw.Stop()
printfn $"Elapsed: %A{sw.Elapsed.TotalMilliseconds} ms"
printfn $"Total sum of invalid IDs: %i{sum}"


printfn "Part 2: Sum of invalid IDs"
printfn "Calculating total sum of invalid IDs..."
let sw2 = Stopwatch.StartNew()
let sum2 = sumInvalidIdsPart2 ranges
sw2.Stop()
printfn $"Elapsed: %A{sw2.Elapsed.TotalMilliseconds} ms"
printfn $"Total sum of invalid IDs: %i{sum2}"
