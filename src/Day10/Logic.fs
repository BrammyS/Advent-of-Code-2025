module Day10.Logic

open System.Collections.Generic
open Day10.Machine

let getMinButtonPresses (machine: Machine) : int option =
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
    input |> Array.map parseMachine |> Array.choose getMinButtonPresses |> Array.sum
