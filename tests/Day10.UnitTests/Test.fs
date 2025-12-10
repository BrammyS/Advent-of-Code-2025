module Day10

open Day10.Machine
open NUnit.Framework
open Shouldly
open Day10.Logic

[<TestCase("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}", 2)>]
[<TestCase("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}", 3)>]
[<TestCase("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}", 2)>]
let getMinButtonPressesForLightsTets (input: string) (expected: int) =
    let machine = parseMachine input
    let result = getMinButtonPressesForLights machine
    result.ShouldBe(Some expected)

[<Test>]
let part1Test () =
    let input =
        [| "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
           "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}"
           "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}" |]

    let result = solvePart1 input
    result.ShouldBe(7)
