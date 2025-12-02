module Day2.Part2

open System
open System.Collections.Generic

let repeatDigit (d: int64) (n: int) : int64 =
    let s = d.ToString()
    let repeated = String.Concat(Array.init n (fun _ -> s))
    Int64.Parse(repeated)

let private amountOfDigits (id: int64) =
    int (Math.Floor(Math.Log10(float id))) + 1

let sumInvalidIdsPart2 (idRanges: array<string>) : int64 =
    let mutable sum = 0L

    for idRange in idRanges do
        let seen = HashSet<int64>()
        let parts = idRange.Split('-')
        let startId = parts.[0] |> Int64.Parse
        let endId = parts.[1] |> Int64.Parse

        for totalDigits in [ amountOfDigits startId .. amountOfDigits endId ] do
            for digits in [ 1 .. (totalDigits / 2) ] do
                if totalDigits % digits = 0 then
                    let times = totalDigits / digits

                    if times >= 2 then
                        let baseMin = if digits = 1 then 1L else pown 10L (digits - 1)
                        let baseMax = pown 10L digits - 1L

                        for baseVal in baseMin..baseMax do
                            let repeatedDigits = repeatDigit baseVal times

                            if repeatedDigits >= startId && repeatedDigits <= endId then
                                if seen.Add(repeatedDigits) then
                                    sum <- sum + repeatedDigits
                                    printfn $"Found invalid ID: %i{repeatedDigits} - in range: %s{idRange} - new sum: %i{sum}"

    sum
