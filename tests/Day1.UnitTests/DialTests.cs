using Shouldly;

namespace Day1.UnitTests;

public class Tests
{
    [TestCase("L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82", 32, 3)]
    [TestCase("R99", 49, 0)]
    [TestCase("L51", 99, 0)]
    [TestCase("L50", 0, 1)]
    [TestCase("L150", 0, 1)]
    [TestCase("r150", 0, 1)]
    [TestCase("L55", 0, 1, 55)]
    [TestCase("L100", 50, 0)]
    [TestCase("R100", 50, 0)]
    [TestCase("L217", 33, 0)]
    public void MovingDailShouldReturnCorrectPositionAndPassword(string input, int expectedPosition, int expectedPassword, int? startingPosition = null)
    {
        // Arrange
        var dial = startingPosition is null ? new Dial() : new Dial(startingPosition.Value);
        var commands = input.Split('\n');

        // Act
        foreach (var command in commands)
        {
            dial.Move(command);
        }

        // Assert
        var finalPosition = dial.GetPosition();
        var finalPassword = dial.GetPassword();
        finalPosition.ShouldBe(expectedPosition);
        finalPassword.ShouldBe(expectedPassword);
    }
}