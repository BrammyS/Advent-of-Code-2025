namespace Day1;

public class Dial(int position = Dial.StartingPosition)
{
    private const int StartingPosition = 50;
    private const int MinPosition = 0;
    private const int MaxPosition = 99;

    private int _position = position;
    private int _password;
    private int _finalPassword;

    public void Move(string command)
    {
        var steps = int.Parse(command[1..]);
        var fullCycles = steps / (MaxPosition + 1);
        steps -= fullCycles * (MaxPosition + 1);
        var finalPasswordIncremented = false;

        var newPosition = _position;
        if (command.StartsWith('L'))
        {
            newPosition -= steps;
            if (newPosition < MinPosition)
            {
                newPosition = MaxPosition + 1 + newPosition;
                if (_position != MinPosition)
                {
                    _finalPassword++;
                    finalPasswordIncremented = true;
                }
            }
        }
        else
        {
            newPosition += steps;
            if (newPosition > MaxPosition)
            {
                newPosition = newPosition - MaxPosition - 1;
                if (_position != MinPosition)
                {
                    _finalPassword++;
                    finalPasswordIncremented = true;
                }
            }
        }

        _position = newPosition;
        if (_position == 0)
        {
            _password++;
            if (!finalPasswordIncremented)
            {
                _finalPassword++;
            }
        }

        _finalPassword += fullCycles;
    }

    public int GetPosition()
    {
        return _position;
    }

    public int GetPassword()
    {
        return _password;
    }

    public int GetFinalPassword()
    {
        return _finalPassword;
    }
}