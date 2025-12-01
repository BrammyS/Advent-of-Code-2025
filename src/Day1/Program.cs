using Day1;

var commands = await File.ReadAllLinesAsync("input.txt");
var dial = new Dial();

Console.WriteLine("Starting Day 1 problem solver...");

foreach (var command in commands)
{
    Console.WriteLine($"Executing command: {command}");
    dial.Move(command);
    Console.WriteLine($"Current Position: {dial.GetPosition()}");
}

Console.WriteLine($"Final Position: {dial.GetPosition()}");
Console.WriteLine($"Password: {dial.GetPassword()}");