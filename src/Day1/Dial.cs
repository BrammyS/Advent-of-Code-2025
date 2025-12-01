namespace Day1;

public class Dial(int position = Dial.StartingPosition)
{
    private const int StartingPosition = 50;
    private const int MinPosition = 0;
    private const int MaxPosition = 99;

    private int _position = position;
    private int _password;

    public void Move(string command)
    {
        var moveLeft = command.StartsWith('L');
        var steps = int.Parse(command[1..]);
        var fullCycles = steps / (MaxPosition + 1);
        steps -= fullCycles * (MaxPosition + 1);
        
        if (moveLeft)
        {
            _position -= steps;
            if (_position < MinPosition)
            {
                _position = MaxPosition + 1 + _position;
            }
        }
        else
        {
            _position += steps;
            if (_position > MaxPosition)
            {
                _position = _position - MaxPosition - 1;
            }
        }

        if (_position == 0)
        {
            _password++;
        }
    }
    
    public int GetPosition()
    {
        return _position;
    }
    
    public int GetPassword()
    {
        return _password;
    }
}