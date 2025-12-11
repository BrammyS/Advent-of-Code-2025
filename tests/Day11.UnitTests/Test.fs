module Day11

open Day11.Logic
open NUnit.Framework
open Shouldly

let exampleInput =
    [| "aaa: you hhh"
       "you: bbb ccc"
       "bbb: ddd eee"
       "ccc: ddd eee fff"
       "ddd: ggg"
       "eee: out"
       "fff: out"
       "ggg: out"
       "hhh: ccc fff iii"
       "iii: out" |]


[<Test>]
let solvePart1Test () =
    let result = solvePart1 exampleInput
    result.ShouldBe(5)