module Day9.Logic

open System.Collections.Generic
open System

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

let getLargestRectangle (lines: array<string>) : KeyValuePair<(Point * Point), int64> =
    let points = parsePoints lines (Array.zeroCreate<Point> lines.Length)
    let allSizes = Dictionary<Point * Point, int64>()

    for i in 0 .. points.Length - 2 do
        for j in i + 1 .. points.Length - 1 do
            let dist = areaSize points[i] points[j]
            allSizes.Add((points[i], points[j]), dist)

    let sortedSizes = allSizes |> Seq.sortByDescending _.Value |> Seq.toArray
    sortedSizes[0]

let solvePart1 (lines: array<string>) : int64 =
    let kvp = getLargestRectangle lines
    kvp.Value
