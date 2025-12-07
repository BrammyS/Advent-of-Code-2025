module Day7

open Day7.Logic
open NUnit.Framework
open Shouldly

let grid =
    [| ".......S......."
       "..............."
       ".......^......."
       "..............."
       "......^.^......"
       "..............."
       ".....^.^.^....."
       "..............."
       "....^.^...^...."
       "..............."
       "...^.^...^.^..."
       "..............."
       "..^...^.....^.."
       "..............."
       ".^.^.^.^.^...^."
       "..............." |]

[<Test>]
let rec sumUniqueBeamsTest () =
    let splits, uniqueBeams = sumBeams grid
    splits.ShouldBe 21
    uniqueBeams.ShouldBe 40
