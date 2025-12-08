module Day8.Logic

open System
open System.Collections.Generic
open Day8.Point

let squaredDistance (p1: Point) (p2: Point) : float =
    let dx = p1.X - p2.X
    let dy = p1.Y - p2.Y
    let dz = p1.Z - p2.Z
    Math.Sqrt(dx * dx + dy * dy + dz * dz)

let getSortedPoints (lines: array<string>) : Dictionary<Point * Point, float> =
    let points = parsePoints lines (Array.zeroCreate<Point> lines.Length)
    let allDistances = Dictionary<Point * Point, float>()

    for i in 0 .. points.Length - 2 do
        for j in i + 1 .. points.Length - 1 do
            let dist = squaredDistance points[i] points[j]
            allDistances.Add((points[i], points[j]), dist)

    let sortedDistances =
        allDistances |> Seq.sortBy (fun kvp -> kvp.Value) |> Seq.toArray

    let sortedDict = Dictionary<Point * Point, float>()

    for kvp in sortedDistances do
        sortedDict.Add(kvp.Key, kvp.Value)

    sortedDict

let connectAndGroupPoints (lines: array<string>) (maxConnections: int64) : List<Set<Point>> * (Point * Point) =
    let sortedDistances: Dictionary<Point * Point, float> = getSortedPoints lines
    let groups = List<Set<Point>>()
    let mutable connections = 0L

    let mutable currentPoints: Point * Point =
        ({ X = 0.0; Y = 0.0; Z = 0.0 }, { X = 0.0; Y = 0.0; Z = 0.0 })

    for kvp in sortedDistances do
        if connections < maxConnections then
            connections <- connections + 1L
            let p1, p2 = kvp.Key
            let mutable group1Index = -1
            let mutable group2Index = -1

            for i in 0 .. groups.Count - 1 do
                if groups[i].Contains p1 then
                    group1Index <- i

                if groups[i].Contains p2 then
                    group2Index <- i

            match group1Index, group2Index with
            | -1, -1 ->
                currentPoints <- kvp.Key
                groups.Add(Set.ofList [ p1; p2 ])
            | i, -1 ->
                currentPoints <- kvp.Key
                groups[i] <- groups[i].Add p2
            | -1, j ->
                currentPoints <- kvp.Key
                groups[j] <- groups[j].Add p1
            | i, j when i <> j ->
                currentPoints <- kvp.Key
                let mergedGroup = Set.union groups[i] groups[j]
                groups[i] <- mergedGroup
                groups.RemoveAt(j)
            | _ -> ()

    groups, currentPoints

let calculatePart1 (lines: array<string>) (maxConnections: int64) : int =
    let groups, _ = connectAndGroupPoints lines maxConnections
    let sortedGroups = groups |> Seq.sortByDescending _.Count |> Seq.toList
    sortedGroups[0].Count * sortedGroups[1].Count * sortedGroups[2].Count

let calculatePart2 (lines: array<string>) : int64 =
    let _, lastPoints = connectAndGroupPoints lines Int64.MaxValue
    let p1, p2 = lastPoints
    int64 p1.X * int64 p2.X
