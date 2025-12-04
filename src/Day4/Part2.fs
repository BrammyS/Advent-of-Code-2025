module Day4.Part2

let neighborIndexes (distance: int) : (int * int)[] =
    [| for r in -distance .. distance do
           for c in -distance .. distance do
               if not (r = 0 && c = 0) then
                   yield (r, c) |]

let to2DCharArray (inputPaperRolls: string[]) =
    let rows = inputPaperRolls.Length
    let cols = inputPaperRolls[0].Length
    let result = Array2D.zeroCreate<char> rows cols

    for r in 0 .. rows - 1 do
        for c in 0 .. cols - 1 do
            result[r, c] <- inputPaperRolls[r][c]

    result

let sumAccessibleRollsOfPaperPart2 (inputPaperRolls: array<string>, maxAdjacent: int, distance: int) : int64 =
    let paperRolls = to2DCharArray inputPaperRolls
    let rows, cols = Array2D.length1 paperRolls, Array2D.length2 paperRolls
    let indexToCheck = neighborIndexes distance
    let isValid r c =  r >= 0 && r < rows && c >= 0 && c < cols

    let rec countNeighbors neighbors idx r c =
        if idx >= Array.length neighbors then 0
        else
            let dr, dc = neighbors[idx]
            let nr, nc = r + dr, c + dc
            let current =
                if isValid nr nc && paperRolls[nr, nc] = '@' then 1
                else 0
            current + countNeighbors neighbors (idx + 1) r c

    let rec loop totalSum =
        let mutable sum = 0L

        for r in 0 .. rows - 1 do
            for c in 0 .. cols - 1 do
                if paperRolls[r, c] = '@' then
                    let neighboringRolls = countNeighbors indexToCheck 0 r c
                    if neighboringRolls < maxAdjacent then
                        sum <- sum + 1L
                        paperRolls[r, c] <- '.'

        if sum = 0L then totalSum else loop (totalSum + sum)

    loop 0L
