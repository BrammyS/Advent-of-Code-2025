module Day2.Part2

open System.Collections.Generic

let repeatDigit (d: int64) (n: int64) : int64 =
    let digitStr = d.ToString()
    let repeatedStr = System.String.Concat(Array.init (int n) (fun _ -> digitStr))
    int64 repeatedStr

let sumInvalidIdsPart2 (idRanges: array<string>) : int64 =
    let mutable sum = 0L

    for idRange in idRanges do
        let seen = HashSet<int64>()
        let parts = idRange.Split('-')
        let startId = parts.[0] |> int64
        let endId = parts.[1] |> int64

        let ids = [ startId..endId ]
        let amountOfDigits (id: int64) = int (log10 (float id)) + 1
        let startDigits = [ 1 .. (amountOfDigits startId) / 2 ]
        let endDigits = [ 1 .. (amountOfDigits endId) / 2 ]

        for digit in (startDigits @ endDigits |> List.distinct) do
            let part1 = $"%i{startId}"[0 .. digit - 1] |> int64
            let part2 = $"%i{endId}"[0 .. digit - 1] |> int64
            let mutable idsToCheck = [ part1..part2 ]

            if part1 > part2 then
                // Not as efficient as it can be but i am going crazy enough already
                idsToCheck <- ([ part1..part2 ] @ [ part2..part1 ]) |> List.distinct

            let timesArr = [(amountOfDigits startId) / digit; (amountOfDigits endId) / digit] |> List.distinct
            for id in idsToCheck do
                for times in timesArr do
                    let potentialInvalidId = repeatDigit id (int64 times)
                    if List.contains potentialInvalidId ids then
                        if seen.Add(potentialInvalidId) then
                            sum <- sum + potentialInvalidId
                            printfn $"Found invalid ID: %i{potentialInvalidId} in range %s{idRange} new sum %i{sum}"
                        //else
                            //printfn $"Duplicated %i{potentialInvalidId} - Wasted precious resources making the north pole melt faster"
                    //else
                        //printfn $"Correct %i{potentialInvalidId} - Wasted precious resources making the north pole melt faster"

    sum