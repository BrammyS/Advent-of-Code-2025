module Day7.Logic

open Microsoft.FSharp.Core.Option

let sumBeams (lines: string array) : int * int64 =
    let startCol = lines[0].IndexOf('S')
    let mutable beams = Map.ofList [ startCol, 1L ]
    let mutable splits = 0
    let rows = lines[1..]

    for row in rows do
        let mutable next = Map.empty

        for beam in beams do
            let col = beam.Key
            let uniqueBeams = beam.Value

            if row[col] = '^' then
                splits <- splits + 1
                let left = col - 1
                let right = col + 1

                if left >= 0 && left < row.Length then
                    let prev = Map.tryFind left next |> defaultValue 0L
                    next <- Map.add left (prev + uniqueBeams) next

                if right >= 0 && right < row.Length then
                    let prev = Map.tryFind right next |> defaultValue 0L
                    next <- Map.add right (prev + uniqueBeams) next
            else
                let prev = Map.tryFind col next |> defaultValue 0L
                next <- Map.add col (prev + uniqueBeams) next

        beams <- next

    splits, beams |> Map.fold (fun acc _ v -> acc + v) 0L
