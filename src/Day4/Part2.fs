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
    let mutable totalSum = 0L
    let mutable sum = 1L

    let paperRolls = to2DCharArray inputPaperRolls
    let rows = Array2D.length1 paperRolls
    let cols = Array2D.length2 paperRolls
    let indexToCheck = neighborIndexes distance

    while sum > 0 do
        sum <- 0L

        for r in 0 .. rows - 1 do
            for c in 0 .. cols - 1 do
                let paperRoll = paperRolls[r, c]

                if paperRoll = '@' then
                    let mutable neighboringRolls = 0L

                    for (checkR, checkC) in indexToCheck do
                        let nr = r + checkR
                        let nc = c + checkC

                        if neighboringRolls < maxAdjacent then
                            if nr >= 0 && nr < rows && nc >= 0 && nc < cols then
                                let neighbor = paperRolls[nr, nc]

                                neighboringRolls <-
                                    if neighbor = '@' then
                                        neighboringRolls + 1L
                                    else
                                        neighboringRolls

                    if neighboringRolls < maxAdjacent then
                        sum <- sum + 1L
                        paperRolls[r, c] <- '.'

        totalSum <- totalSum + sum

    totalSum
