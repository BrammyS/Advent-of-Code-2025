module Day10.Machine

open System.Text.RegularExpressions

type Machine = { Target: bool[]; Buttons: int list[]; JoltageRequirements: int[] }

let parseMachine (line: string) : Machine =
    let indicatorMatch = Regex.Match(line, @"\[([.#]+)\]")
    let buttonMatches = Regex.Matches(line, @"\(([0-9,]+)\)")
    let joltageMatch = Regex.Match(line, @"\{([0-9,]+)\}")
    
    let indicator = indicatorMatch.Groups[1].Value
    let target = indicator |> Seq.map (fun c -> c = '#') |> Seq.toArray

    let buttons =
        buttonMatches
        |> Seq.cast<Match>
        |> Seq.map (fun m -> m.Groups[1].Value.Split(',') |> Array.map int |> Array.toList)
        |> Seq.toArray

    let joltageRequirements =
        if joltageMatch.Success then
            joltageMatch.Groups[1].Value.Split(',') |> Array.map int
        else
            Array.empty

    { Target = target; Buttons = buttons; JoltageRequirements = joltageRequirements }
