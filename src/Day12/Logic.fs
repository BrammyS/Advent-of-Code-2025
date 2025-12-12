module Day12.Logic

open System

type PresentShape = string list

type Region =
    { Width: int
      Height: int
      PresentCounts: int list }

let parseShape (lines: string list) : PresentShape = List.tail lines
let calculateShapeArea = Seq.sumBy (Seq.filter ((=) '#') >> Seq.length)

let parseRegion (line: string) : Region =
    let parts = line.Split(':')
    let dimensions = parts[0].Trim().Split('x')
    let width = int dimensions[0]
    let height = int dimensions[1]
    let countStrings = parts[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
    let counts = Array.zeroCreate countStrings.Length

    for i = 0 to countStrings.Length - 1 do
        counts[i] <- int countStrings[i]

    { Width = width
      Height = height
      PresentCounts = Array.toList counts }

let parseInput (input: string) : Map<int, int> * Region list =
    let groups = input.Replace("\r\n", "\n").Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
    let shapeGroups = Array.sub groups 0 (groups.Length - 1)
    let regionGroup = groups[groups.Length - 1]
    let shapeAreas = Array.zeroCreate shapeGroups.Length

    for i = 0 to shapeGroups.Length - 1 do
        let lines = shapeGroups[i].Split([| '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
        shapeAreas[i] <- (i, calculateShapeArea (parseShape (Array.toList lines)))

    let regionLines = regionGroup.Split([| '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
    let regions = Array.zeroCreate regionLines.Length

    for i = 0 to regionLines.Length - 1 do
        regions[i] <- parseRegion regionLines[i]

    (Map.ofArray shapeAreas, Array.toList regions)

let canFitPresents (shapeAreas: Map<int, int>) (region: Region) : bool =
    let mutable totalPresentArea = 0
    let mutable idx = 0

    for count in region.PresentCounts do
        totalPresentArea <- totalPresentArea + (count * shapeAreas[idx])
        idx <- idx + 1

    let regionArea = region.Width * region.Height
    totalPresentArea <= regionArea

let solvePart1 (input: string) : int =
    let shapeAreas, regions = parseInput input
    let mutable count = 0

    for region in regions do
        if canFitPresents shapeAreas region then
            count <- count + 1

    count
