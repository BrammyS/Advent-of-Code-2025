using Shouldly;

namespace Day1.UnitTests;

public class Tests
{
    [TestCase("L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82", 32, 3, 6)]
    [TestCase("R99", 49, 0, 1)]
    [TestCase("L51", 99, 0, 1)]
    [TestCase("L50", 0, 1, 1)]
    [TestCase("L150", 0, 1, 2)]
    [TestCase("r150", 0, 1, 2)]
    [TestCase("L55", 0, 1, 1, 55)]
    [TestCase("L100", 50, 0, 1)]
    [TestCase("R100", 50, 0, 1)]
    [TestCase("L217", 33, 0, 2)]
    [TestCase("R60", 55, 0, 1, 95)]
    [TestCase("L68", 82, 0, 1)]
    [TestCase("L82", 32, 0, 1, 14)]
    [TestCase("L5", 95, 0, 0, 0)]
    [TestCase("R48", 0, 1, 1, 52)]
    public void MovingDailShouldReturnCorrectPositionAndPassword(
        string input,
        int expectedPosition,
        int expectedPassword,
        int expectedFinalPassword,
        int? startingPosition = null
    )
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
        var position = dial.GetPosition();
        var password = dial.GetPassword();
        var finalPassword = dial.GetFinalPassword();
        position.ShouldBe(expectedPosition);
        password.ShouldBe(expectedPassword);
        finalPassword.ShouldBe(expectedFinalPassword);
    }
}