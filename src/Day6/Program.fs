open System.Diagnostics
open System.IO
open Day6.Logic

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")

// Warm up
for i in 0..50 do
    let a, b = parseLinesPart1 lines
    doMathHomeWorkPart1 a b |> ignore

let sw1 = Stopwatch.StartNew()
let reversedLines = lines |> Array.map (fun s -> new string (s.ToCharArray() |> Array.rev))
let numbersPart1, charsPart1 = parseLinesPart1 lines
let part1 = doMathHomeWorkPart1 numbersPart1 charsPart1
sw1.Stop()
printfn $"Part 1 Sum: {part1}"
printfn $"Part 1 Elapsed in: %A{sw1.Elapsed.TotalMilliseconds} ms"


let sw2 = Stopwatch.StartNew()
let part2 = doMathHomeWorkPart2 lines
sw2.Stop()
printfn $"Part 2 Sum: {part2}"
printfn $"Part 2 Elapsed in: %A{sw2.Elapsed.TotalMilliseconds} ms"