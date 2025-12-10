module Day10.Logic

open System.Collections.Generic
open Day10.Machine

let getMinButtonPressesForLights (machine: Machine) : int option =
    let numLights = machine.Target.Length
    let numButtons = machine.Buttons.Length

    let applyButtons (buttonPresses: Set<int>) : bool[] =
        let lights = Array.create numLights false

        for buttonIdx in buttonPresses do
            for lightIdx in machine.Buttons[buttonIdx] do
                lights[lightIdx] <- not lights[lightIdx]

        lights

    let lightsMatchMachine (lights: bool[]) : bool = Array.forall2 (=) lights machine.Target
    let queue = Queue<Set<int>>()
    let visited = HashSet<Set<int>>()

    queue.Enqueue(Set.empty)
    visited.Add(Set.empty) |> ignore

    let mutable found = None

    // BFS loop
    while queue.Count > 0 && found.IsNone do
        let buttonsToPress = queue.Dequeue()
        let resultingLights = applyButtons buttonsToPress

        if lightsMatchMachine resultingLights then
            found <- Some(Set.count buttonsToPress)
        else
            for buttonIndex = 0 to numButtons - 1 do
                if not (buttonsToPress.Contains buttonIndex) then
                    let nextCombination = Set.add buttonIndex buttonsToPress

                    if not (visited.Contains nextCombination) then
                        visited.Add(nextCombination) |> ignore
                        queue.Enqueue(nextCombination)

    found

let solvePart1 (input: string[]) : int =
    input
    |> Array.map parseMachine
    |> Array.choose getMinButtonPressesForLights
    |> Array.sum

let getMinButtonPressesForJoltage (machine: Machine) : int option =
    use ctx = new Microsoft.Z3.Context()
    use optimizer = ctx.MkOptimize()
    let numButtons = machine.Buttons.Length
    let numCounters = machine.JoltageRequirements.Length
    let buttonVars = [| for i in 0 .. numButtons - 1 -> ctx.MkIntConst($"button_{i}") |]

    for buttonVar in buttonVars do
        optimizer.Assert(ctx.MkGe(buttonVar, ctx.MkInt(0)))

    for counterIdx in 0 .. numCounters - 1 do
        let targetJoltage = machine.JoltageRequirements[counterIdx]

        let contributions =
            [| for buttonIdx in 0 .. numButtons - 1 do
                   if machine.Buttons[buttonIdx] |> List.contains counterIdx then
                       yield buttonVars[buttonIdx] |]

        if contributions.Length > 0 then
            let sum = ctx.MkAdd(contributions |> Array.map (fun x -> x :> Microsoft.Z3.ArithExpr))
            optimizer.Assert(ctx.MkEq(sum, ctx.MkInt(targetJoltage)))
        else if targetJoltage <> 0 then
            optimizer.Assert(ctx.MkFalse())

    let totalPresses = ctx.MkAdd(buttonVars |> Array.map (fun x -> x :> Microsoft.Z3.ArithExpr))
    optimizer.MkMinimize(totalPresses) |> ignore

    match optimizer.Check() with
    | Microsoft.Z3.Status.SATISFIABLE ->
        let model = optimizer.Model
        let total = buttonVars |> Array.sumBy (fun v -> model.Eval(v, true).ToString() |> int)
        Some total
    | _ ->
        None

let solvePart2 (input: string[]) : int =
    input
    |> Array.map parseMachine
    |> Array.choose getMinButtonPressesForJoltage
    |> Array.sum
