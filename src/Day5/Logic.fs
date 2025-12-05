module Day5.Logic

open System.Collections.Generic

let rec getFreshIds (validIdRanges: string[]) (index: int) (freshIds: array<int64 * int64>) : array<int64 * int64> =
    if index < validIdRanges.Length then
        let currentRange = validIdRanges[index].Split '-'
        freshIds[index] <- int64 currentRange[0], int64 currentRange[1]
        getFreshIds validIdRanges (index + 1) freshIds
    else
        freshIds

let rec sumSpoiled (freshIds: array<int64 * int64>) (ids: string[]) (index: int) (spoiledIds: int) (seen: HashSet<int64>) : int =
    if index < ids.Length then
        let currentId = int64 ids[index]
        let mutable count = 0

        for startId, endId in freshIds do
            if (not (seen.Contains currentId)) && currentId >= startId && currentId <= endId then
                count <- count + 1
                seen.Add currentId |> ignore

        sumSpoiled freshIds ids (index + 1) (spoiledIds + count) seen
    else
        spoiledIds

// Part 2
let rec mergeAndSumFreshIds remaining currentStartId currentEndId total =
    match remaining with
    | [||] -> total + (currentEndId - currentStartId + 1L)
    | _ ->
        let newStartId, newEndId = remaining[0]
        let tail = remaining.[1..]

        if newStartId <= currentEndId then
            let mergedEndId = max currentEndId newEndId
            mergeAndSumFreshIds tail currentStartId mergedEndId total
        else
            let newTotal = total + (currentEndId - currentStartId + 1L)
            mergeAndSumFreshIds tail newStartId newEndId newTotal

let sumFreshIds (freshIds: array<int64 * int64>) : int64 =
    let sortedIds = Array.sortBy fst freshIds
    let startId, endId = sortedIds[0]
    mergeAndSumFreshIds sortedIds.[1..] startId endId 0L
