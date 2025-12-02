module Day2.Part1

let sumInvalidIdsPart1 (idRanges: array<string>) : int64 =
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
