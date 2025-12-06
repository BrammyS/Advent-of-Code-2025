module Day6.Logic

open System

let splitCol (x: string) : string array =
    x.Split(' ', StringSplitOptions.RemoveEmptyEntries)

let splitColInt64 (x: string) : int64 array = splitCol x |> Array.map int64
let splitColChar (x: string) : char array = splitCol x |> Array.map char

let parseLines (lines: array<string>) : (int64 array2d * array<char>) =
    let rows = lines.Length
    let cols = (splitColInt64 lines[0]).Length
    let parsed = Array2D.zeroCreate<int64> (rows - 1) cols

    // -2 because the last row contains chars (* OR +) :)
    for i in 0 .. rows - 2 do
        let nums = splitColInt64 lines[i]

        for j in 0 .. cols - 1 do
            parsed[i, j] <- nums[j]

    parsed, splitColChar lines[rows - 1]

let doMathHomeWork (lines: array<string>) : int64 =
    let numbers, chars = parseLines lines
    let rows = Array2D.length1 numbers
    let cols = Array2D.length2 numbers
    let mutable total = 0L

    for col in 0 .. cols - 1 do
        let mutable sum = numbers[0, col]
        let char = chars[col]

        for row in 1 .. rows - 1 do
            if char = '*' then
                sum <- sum * numbers[row, col]
            else
                sum <- sum + numbers[row, col]

        total <- total + sum

    total
