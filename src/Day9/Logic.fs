module Day9.Logic

open System
open System.Collections.Concurrent
open System.Collections.Generic
open System.Threading.Tasks

type Point = { X: int64; Y: int64 }

let parsePoint (line: string) : Point =
    let parts = line.Split(',')

    { X = int64 parts[0]
      Y = int64 parts[1] }

let rec parsePoints (lines: string[]) (points: Point array) : Point array =
    if lines.Length > 0 then
        points[points.Length - lines.Length] <- parsePoint lines[0]
        parsePoints lines[1..] points
    else
        points

let areaSize (p1: Point) (p2: Point) : int64 =
    let width = Math.Abs(p1.X - p2.X) + 1L
    let height = Math.Abs(p1.Y - p2.Y) + 1L
    int64 (width * height)

let pointInPolygon (points: Point array) (p: Point) =
    let mutable inside = false
    let n = points.Length

    for i in 0 .. n - 1 do
        let a = points[i]
        let b = points[(i + 1) % n]
        let edgeCrossesHorizontalRay = (a.Y > p.Y) <> (b.Y > p.Y)

        // If the result of the wizardry is true we flip the inside flag :)
        if edgeCrossesHorizontalRay then
            let verticalProgressRatio = float (p.Y - a.Y) / float (b.Y - a.Y)
            let horizontalEdgeLength = float (b.X - a.X)
            let horizontalOffset = verticalProgressRatio * horizontalEdgeLength
            let rayIntersectionX = float a.X + horizontalOffset

            if float p.X < rayIntersectionX then
                // Flipped uneven number of times means inside :)
                inside <- not inside

    inside

let isOnBoundary (p: Point) (poly: Point array) =
    let mutable onEdge = false

    for i in 0 .. poly.Length - 1 do
        let a = poly[i]
        let b = poly[(i + 1) % poly.Length]

        let minXEdge = min a.X b.X
        let maxXEdge = max a.X b.X
        let minYEdge = min a.Y b.Y
        let maxYEdge = max a.Y b.Y

        // This somehow works to check if point is on edge :)
        if p.X >= minXEdge && p.X <= maxXEdge && p.Y >= minYEdge && p.Y <= maxYEdge then
            if a.X = b.X && p.X = a.X then
                onEdge <- true
            elif a.Y = b.Y && p.Y = a.Y then
                onEdge <- true
            elif (p.Y - a.Y) * (b.X - a.X) = (b.Y - a.Y) * (p.X - a.X) then
                onEdge <- true

    onEdge

let isInsideOfShape (p1: Point) (p2: Point) (points: array<Point>) : bool =
    let minX = min p1.X p2.X
    let maxX = max p1.X p2.X
    let minY = min p1.Y p2.Y
    let maxY = max p1.Y p2.Y

    let isInsideOrOnBoundary (p: Point) =
        isOnBoundary p points || pointInPolygon points p

    let corners =
        [ { X = minX; Y = minY }
          { X = minX; Y = maxY }
          { X = maxX; Y = minY }
          { X = maxX; Y = maxY } ]

    let allCornersInside = corners |> List.forall isInsideOrOnBoundary

    if not allCornersInside then
        false
    else
        let mutable allInside = true
        let mutable x = minX

        while x <= maxX && allInside do
            let mutable y = minY

            while y <= maxY && allInside do
                let p = { X = x; Y = y }

                if not (isInsideOrOnBoundary p) then
                    allInside <- false

                y <- y + 1L

            x <- x + 1L

        allInside

let getLargestRectangleThatFitInsideShape (lines: array<string>) : KeyValuePair<Point * Point, int64> =
    let points = parsePoints lines (Array.zeroCreate<Point> lines.Length)
    let allSizes = ConcurrentDictionary<Point * Point, int64>()
    let progress = ConcurrentDictionary<int, bool>()

    Parallel.For(
        0,
        points.Length - 1,
        fun i ->
            for j in i + 1 .. points.Length - 1 do
                if isInsideOfShape points[i] points[j] points then
                    let dist = areaSize points[i] points[j]
                    allSizes.TryAdd((points[i], points[j]), dist) |> ignore

            progress.TryAdd(i, true) |> ignore
            let percentComplete = (float progress.Count / float (points.Length - 1)) * 100.0
            let timeStamp = DateTime.Now.ToString("HH:mm:ss")
            printfn $"[{timeStamp}] Progress: {percentComplete:F2}%% ({progress.Count}/{points.Length - 1})"
    )
    |> ignore

    if allSizes.Count = 0 then
        failwith "No rectangles found"

    let sortedSizes = allSizes |> Seq.sortByDescending _.Value |> Seq.toArray
    sortedSizes[0]

let solvePart1 (lines: array<string>) : int64 =
    let points = parsePoints lines (Array.zeroCreate<Point> lines.Length)
    let allSizes = Dictionary<Point * Point, int64>()

    for i in 0 .. points.Length - 2 do
        for j in i + 1 .. points.Length - 1 do
            let dist = areaSize points[i] points[j]
            allSizes.Add((points[i], points[j]), dist)

    let sortedSizes = allSizes |> Seq.sortByDescending _.Value |> Seq.toArray
    sortedSizes[0].Value

let solvePart2 (lines: array<string>) : int64 =
    let kvp = getLargestRectangleThatFitInsideShape lines
    kvp.Value
