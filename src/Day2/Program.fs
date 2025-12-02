let sumInvalidIds (idRanges: array<string>) : int =
    let mutable sum = 0

    for idRange in idRanges do
        let parts = idRange.Split('-')
        let ids = [ parts.[0] |> int .. parts.[1] |> int ]
        
        let isEven id = (id % 2) = 0
        let amountOfDigits id = int (log10 (float id)) + 1
        let idsToValidate = List.filter (fun x -> isEven (amountOfDigits x)) ids
        
        let firstPart id digits= (id / (pown 10 digits - 1) )
        let test = firstPart 11 2
        printfn $"%i{test}"
        let validateId id digits = (id / (pown 10 digits - 1) ) = (id % (pown 10 digits - 1) )
        let invalidIds = List.filter (fun x -> validateId x (amountOfDigits x)) idsToValidate
        let newSum = List.sum invalidIds
        sum <- sum + newSum
    sum
