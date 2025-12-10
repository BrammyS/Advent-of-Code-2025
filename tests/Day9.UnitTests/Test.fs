module Day9

open Day9.Logic
open NUnit.Framework
open Shouldly

let lines = [| "7,1"; "11,1"; "11,7"; "9,7"; "9,5"; "2,5"; "2,3"; "7,3" |]

[<Test>]
let solvePart1Test () =
    let result = solvePart1 lines
    result.ShouldBe 50

[<Test>]
let solvePart2Test () =
    let result = solvePart2 lines
    result.ShouldBe 24
