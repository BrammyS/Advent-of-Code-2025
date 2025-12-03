module Day3

open Day3.Logic
open NUnit.Framework
open Shouldly

[<TestCase("987654321111111", 98L)>]
[<TestCase("811111111111119", 89L)>]
[<TestCase("234234234234278", 78L)>]
[<TestCase("818181911112111", 92L)>]
let CalculateJoltagePart1ShouldReturnCorrectValue (batteryBank: string, expected: int64) =
    calculateJoltage([| batteryBank |], 2).ShouldBe(expected)
