module Day2

open NUnit.Framework
open Program
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
let sumInvalidIdsShouldReturnCorrectSum range expected =
    sumInvalidIds(range).ShouldBeEquivalentTo(expected)
