open System.Collections.Generic
open System.Diagnostics
open System.IO
open Day5.Logic

printfn "Reading input file..."
let rangesLines = File.ReadAllLines("./inputRanges.txt")
let idLines = File.ReadAllLines("./inputIds.txt")

// Warm up
for i in 0..50 do
    getFreshIds rangesLines 0 |> ignore

let sw1 = Stopwatch.StartNew()
let freshIds1 = getFreshIds rangesLines 0 (Array.zeroCreate rangesLines.Length)
printfn $"Fresh ids: %i{freshIds1.Length}"
let sumPart1 = sumSpoiled freshIds1 idLines 0 0 (HashSet<int64>())
sw1.Stop()
printfn $"Elapsed: %A{sw1.Elapsed.TotalMilliseconds} ms"
printfn $"Part 1 sum: {sumPart1}"

let sw2 = Stopwatch.StartNew()
let freshIds2 = getFreshIds rangesLines 0 (Array.zeroCreate rangesLines.Length)
let freshIds = sumFreshIds freshIds2
sw2.Stop()
printfn $"Elapsed: %A{sw2.Elapsed.TotalMilliseconds} ms"
printfn $"Part 2 sum: {freshIds}"
