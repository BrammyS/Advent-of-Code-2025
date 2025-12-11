module Day11.Logic

open System.Collections.Generic

let parseDevice (line: string) : string * string list =
    let parts = line.Split(':')
    let name = parts[0].Trim()

    let children =
        if parts.Length > 1 then
            parts[1].Trim().Split(' ') |> Array.map _.Trim() |> Array.toList
        else
            []

    name, children

let buildDeviceMap (lines: string[]) : Map<string, string list> =
    lines |> Array.map parseDevice |> Map.ofArray

let countPaths (deviceMap: Map<string, string list>) (start: string) (target: string) (cache: Dictionary<string * string, int64>) : int64 =
    let stack = Stack<string * bool>()
    stack.Push((start, false))

    while stack.Count > 0 do
        let current, visited = stack.Pop()
        let key = (current, target)

        if cache.ContainsKey(key) then
            ()
        elif current = target then
            cache[key] <- 1L
        elif visited then
            let children = deviceMap.TryFind(current) |> Option.defaultValue []

            let mutable total = 0L

            for child in children do
                total <- total + cache[(child, target)]

            cache[key] <- total
        else
            stack.Push((current, true))
            let children = deviceMap.TryFind(current) |> Option.defaultValue []

            for child in children do
                if not (cache.ContainsKey((child, target))) then
                    stack.Push((child, false))

    cache[(start, target)]

let solvePart1 (lines: string[]) : int64 =
    let deviceMap = buildDeviceMap lines
    let cache = Dictionary<string * string, int64>()
    countPaths deviceMap "you" "out" cache

let solvePart2 (lines: string[]) : int64 =
    let deviceMap = buildDeviceMap lines
    let cache = Dictionary<string * string, int64>()

    // paths from svr, dac, fft, out
    let svrToDac = countPaths deviceMap "svr" "dac" cache
    let dacToFft = countPaths deviceMap "dac" "fft" cache
    let fftToOut = countPaths deviceMap "fft" "out" cache
    let pathsToOut1 = svrToDac * dacToFft * fftToOut

    // paths from svr, fft, dac, out
    let svrToFft = countPaths deviceMap "svr" "fft" cache
    let fftToDac = countPaths deviceMap "fft" "dac" cache
    let dacTpOut = countPaths deviceMap "dac" "out" cache
    let pathsToOut2 = svrToFft * fftToDac * dacTpOut

    pathsToOut1 + pathsToOut2
