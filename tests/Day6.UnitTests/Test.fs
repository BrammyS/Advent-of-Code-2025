module Day6

open Day6.Logic
open NUnit.Framework
open Shouldly

[<TestCase "123 328  51 64\n45 64  387 23 \n6 98  215 314\n*   +   *   + ">]
let parseLinesTest  (input: string) =
    let lines = input.Split '\n'
    let (numbers, chars) = parseLines lines
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
let doMathHomeWorkTest (input: string) =
    let lines = input.Split '\n'
    let result = doMathHomeWork lines
    result.ShouldBe 4277556