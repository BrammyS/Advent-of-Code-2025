module Day2

open Day2.Part1
open Day2.Part2
open NUnit.Framework
open Shouldly

[<TestCase([| "11-22" |], 33L)>]
[<TestCase([| "95-115" |], 99L)>]
[<TestCase([| "996-1012" |], 1010L)>]
[<TestCase([| "1188511880-1188511890" |], 1188511885L)>]
[<TestCase([| "222220-222224" |], 222222L)>]
[<TestCase([| "1698522-1698528" |], 0L)>]
[<TestCase([| "446443-446449" |], 446446L)>]
[<TestCase([| "38593856-38593862" |], 38593859L)>]
[<TestCase([| "11-22"
              "95-115"
              "998-1012"
              "1188511880-1188511890"
              "222220-222224"
              "1698522-1698528"
              "446443-446449"
              "38593856-38593862"
              "565653-565659"
              "824824821-824824827"
              "2121212118-2121212124" |],
           1227775554L)>]
let sumInvalidIdsShouldReturnCorrectSumPart1 range expected =
    sumInvalidIdsPart1(range).ShouldBeEquivalentTo(expected)


[<TestCase([| "1111111-1111112" |], 1111111L)>]
[<TestCase([| "1111111-3111112" |], 3333333L)>]
[<TestCase([| "11-22" |], 33L)>]
[<TestCase([| "3065-3552" |], 16665L)>]
[<TestCase([| "95-115" |], 210L)>]
[<TestCase([| "996-1012" |], 2009)>]
[<TestCase([| "1188511880-1188511890" |], 1188511885L)>]
[<TestCase([| "222220-222224" |], 222222L)>]
[<TestCase([| "1698522-1698528" |], 0L)>]
[<TestCase([| "446443-446449" |], 446446L)>]
[<TestCase([| "38593856-38593862" |], 38593859L)>]
[<TestCase([| "11-22"
              "95-115"
              "998-1012"
              "1188511880-1188511890"
              "222220-222224"
              "1698522-1698528"
              "446443-446449"
              "38593856-38593862"
              "565653-565659"
              "824824821-824824827"
              "2121212118-2121212124" |],
           4174379265L)>]
let sumInvalidIdsShouldReturnCorrectSumPart2 range expected =
    sumInvalidIdsPart2(range).ShouldBe(expected)