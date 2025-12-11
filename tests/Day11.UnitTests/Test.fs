module Day11

open Day11.Logic
open NUnit.Framework
open Shouldly

let exampleInputPart1 =
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
    let result = solvePart1 exampleInputPart1
    result.ShouldBe(5)

let exampleInputPart2 =
    [| "svr: aaa bbb"
       "aaa: fft"
       "fft: ccc"
       "bbb: tty"
       "tty: ccc"
       "ccc: ddd eee"
       "ddd: hub"
       "hub: fff"
       "eee: dac"
       "dac: fff"
       "fff: ggg hhh"
       "ggg: out"
       "hhh: out" |]

[<Test>]
let solvePart2Test () =
    let result = solvePart2 exampleInputPart2
    result.ShouldBe(2L)
