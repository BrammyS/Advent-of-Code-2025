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

let countPaths (deviceMap: Map<string, string list>) (start: string) (target: string) : int =
    let mutable count = 0
    let stack = Stack<string>()
    stack.Push(start)

    while stack.Count > 0 do
        let current = stack.Pop()

        if current = target then
            count <- count + 1
        else
            match Map.tryFind current deviceMap with
            | None -> ()
            | Some children ->
                for child in children do
                    stack.Push(child)

    count

let solvePart1 (lines: string[]) : int =
    let deviceMap = buildDeviceMap lines
    countPaths deviceMap "you" "out"
