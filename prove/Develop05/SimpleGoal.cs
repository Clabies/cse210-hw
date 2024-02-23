using System;

class SimpleGoal : Goal
{
    private bool _isGoalCompleted = false;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        if (_isGoalCompleted)
        {
            Console.WriteLine($"You have already completed this task!");
            return;
        }
        _isGoalCompleted = true;
        Console.WriteLine($"Congratulations! You have earned {_points} point!");
    }

    public override bool IsComplete()
    {
        return _isGoalCompleted;
    }

    public override string GetStringRepresentation()
    {
        string mark = _isGoalCompleted ? "X" : " ";
        return $"[{mark}] {_shortName} ({_description})";
    }

    public void SetIsGoalCompleted(bool value)
    {
        _isGoalCompleted = value;
    }
}