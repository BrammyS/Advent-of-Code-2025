module Day4

open Day4.Part1
open Day4.Part2
open NUnit.Framework
open Shouldly

[<TestCase("..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.", 4, 1, 13)>]
let getTotalAccessibleRollsOfPaperPart1 (rolls: string, maxAdjacent: int, distance: int, expected: int64) =
    sumAccessibleRollsOfPaperPart1(rolls.Split '\n', maxAdjacent, distance).ShouldBe(expected)
    
[<TestCase("..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.", 4, 1, 43)>]
let getTotalAccessibleRollsOfPaperPart2 (rolls: string, maxAdjacent: int, distance: int, expected: int64) =
    sumAccessibleRollsOfPaperPart2(rolls.Split '\n', maxAdjacent, distance).ShouldBe(expected)