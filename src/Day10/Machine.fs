module Day10.Machine

open System.Text.RegularExpressions

type Machine = { Target: bool[]; Buttons: int list[] }

let parseMachine (line: string) : Machine =
    let indicatorMatch = Regex.Match(line, @"\[([.#]+)\]")
    let buttonMatches = Regex.Matches(line, @"\(([0-9,]+)\)")
    let indicator = indicatorMatch.Groups[1].Value
    let target = indicator |> Seq.map (fun c -> c = '#') |> Seq.toArray

    let buttons =
        buttonMatches
        |> Seq.cast<Match>
        |> Seq.map (fun m -> m.Groups[1].Value.Split(',') |> Array.map int |> Array.toList)
        |> Seq.toArray

    { Target = target; Buttons = buttons }
