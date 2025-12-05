module Day5

open System.Collections.Generic
open Day5.Logic
open NUnit.Framework
open Shouldly

[<Test>]
let sumFreshIdsTest (): unit =
    let rangeLines: string[] = [| "3-5"; "10-14"; "16-20"; "12-18"; "15-16"; "30-40"; "34-36" |]
    let ranges = getFreshIds rangeLines 0 (Array.zeroCreate rangeLines.Length)
    let result = sumFreshIds ranges
    result.ShouldBe 25L
    

[<Test>]
let sumSpoiled (): unit =
    let rangeLines: string[] = [| "3-5"; "10-14"; "16-20"; "12-18" |]
    let idLines: string[] = [| "1"; "5"; "8"; "11"; "17"; "32" |]
    
    let ranges = getFreshIds rangeLines 0 (Array.zeroCreate rangeLines.Length)
    let invalidIds = sumSpoiled ranges idLines 0 0 (HashSet<int64>())
    invalidIds.ShouldBe 3