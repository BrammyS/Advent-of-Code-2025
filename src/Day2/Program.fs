open System.IO
open System.Diagnostics

let sumInvalidIds (idRanges: array<string>) : int64 =
    let mutable sum = 0L

    for idRange in idRanges do
        let parts = idRange.Split('-')
        let amountOfDigits (id: int64) = int (log10 (float id)) + 1

        let idsToValidate ids =
            List.filter (fun (x: int64) -> (amountOfDigits x % 2) = 0) ids

        let invalidIds =
            List.filter
                (fun (x: int64) ->
                    let partSize = pown 10L ((amountOfDigits x) / 2)
                    x / partSize = x % partSize)
                (idsToValidate [ parts.[0] |> int64 .. parts.[1] |> int64 ])

        sum <- sum + List.sum invalidIds

    sum

printfn "Reading input file..."
let lines = File.ReadAllLines("./input.txt")
let ranges = lines[0].Split ','


printfn "Calculating total sum of invalid IDs..."
let sw = Stopwatch.StartNew()
let sum = sumInvalidIds ranges
sw.Stop()
printfn $"Elapsed: %A{sw.Elapsed.TotalMilliseconds} ms"
printfn $"Total sum of invalid IDs: %i{sum}"