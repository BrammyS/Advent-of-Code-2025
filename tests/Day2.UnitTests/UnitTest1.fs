module Day2

open NUnit.Framework
open Program
open Shouldly

[<Test>]
let Test1 () =
    sumInvalidIds([|"11-22"|]).ShouldBeEquivalentTo(33)