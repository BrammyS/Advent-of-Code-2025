module Day6

open Day6.Logic
open NUnit.Framework
open Shouldly

[<TestCase "123 328  51 64\n45 64  387 23 \n6 98  215 314\n*   +   *   + ">]
let parseLinesPart1Test (input: string) =
    let lines = input.Split '\n'
    let numbers, chars = parseLinesPart1 lines
    let rows = Array2D.length1 numbers
    let cols = Array2D.length2 numbers
    rows.ShouldBe 3
    numbers[0, 0].ShouldBe 123
    numbers[0, 1].ShouldBe 328
    numbers[2, 2].ShouldBe 215

    cols.ShouldBe 4
    chars.Length.ShouldBe 4
    chars[0].ShouldBe '*'
    chars[1].ShouldBe '+'
    chars[2].ShouldBe '*'


[<TestCase "123 328  51 64\n45 64  387 23 \n6 98  215 314\n*   +   *   + ">]
let doMathHomeWorkPart1Test (input: string) =
    let lines = input.Split '\n'
    let numbers, chars = parseLinesPart1 lines
    let result = doMathHomeWorkPart1 numbers chars
    result.ShouldBe 4277556
    
[<TestCase("123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +   ", 3263827)>]
[<TestCase(" 8\n 6\n74\n54\n* ", 648300)>]
[<TestCase("72 \n63 \n563\n763\n*  ", 597843246)>]
let doMathHomeWorkPart2Test (input: string) (expected: int64) =
    let lines = input.Split '\n'
    let result = doMathHomeWorkPart2 lines
    result.ShouldBe expected
