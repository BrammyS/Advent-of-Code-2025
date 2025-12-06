module Day6.Logic

open System
open System.Text

let splitCol (x: string) : string array =
    x.Split(' ', StringSplitOptions.RemoveEmptyEntries)

let splitColInt64 (x: string) : int64 array = splitCol x |> Array.map int64
let splitColChar (x: string) : char array = splitCol x |> Array.map char

let parseLinesPart1 (lines: array<string>) : int64 array2d * array<char> =
    let rows = lines.Length
    let cols = (splitColInt64 lines[0]).Length
    let parsed = Array2D.zeroCreate<int64> (rows - 1) cols

    for i in 0 .. rows - 2 do
        let nums = splitColInt64 lines[i]

        for j in 0 .. cols - 1 do
            parsed[i, j] <- nums[j]

    parsed, splitColChar lines[rows - 1]

let doMathHomeWorkPart1 (numbers: int64 array2d) (chars: array<char>) : int64 =
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

let doMathHomeWorkPart2 (lines: array<string>) : int64 =
    let rows = lines.Length
    let cols = lines[0].Length
    let operatorRow = rows - 1
    let mutable total = 0L
    let numbers = ResizeArray<int64>()

    for col = cols - 1 downto 0 do
        let digits = StringBuilder()

        for row = 0 to operatorRow - 1 do
            let ch = lines[row][col]

            if ch <> ' ' then
                digits.Append(ch) |> ignore

        if digits.Length > 0 then
            numbers.Add(int64 (digits.ToString()))

        let operatorChar = lines[operatorRow][col]

        if operatorChar <> ' ' && numbers.Count > 0 then
            let result =
                if operatorChar = '*' then
                    numbers |> Seq.reduce (fun acc value -> acc * value)
                else
                    numbers |> Seq.reduce (fun acc value -> acc + value)

            total <- total + result
            numbers.Clear()

    total
