using System;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected string _points;
    protected string _shortName;

    public Goal(string name, string description, string points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with goal? ");
        _points = Console.ReadLine();
        return "";
    }

    public abstract string GetStringRepresentation();

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual string GetPoints()
    {
        return _points;
    }

    public virtual int GetBonus()
    {
        return 0;
    }

    public virtual int GetTarget()
    {
        return 0;
    }

    public virtual int GetAmountCompleted()
    {
        return 0;
    }

    public static Goal ConvertToGoal(RequestDTO goalDTO)
    {
        string typeOfGoal = goalDTO.GoalType;
        switch (typeOfGoal)
        {
            case "SimpleGoal":
                SimpleGoal simpleGoal = new SimpleGoal(goalDTO.ShortName, goalDTO.Description, goalDTO.Points);
                return simpleGoal;
            case "EternalGoal":
                return new EternalGoal(goalDTO.ShortName, goalDTO.Description, goalDTO.Points);
            case "ChecklistGoal":
                ChecklistGoal checklistGoal = new ChecklistGoal(goalDTO.ShortName, goalDTO.Description, goalDTO.Points, goalDTO.Target, goalDTO.Bonus);
                return checklistGoal;
            default:
                throw new ArgumentException($"Invalid goal type: {typeOfGoal}");
        }
    }
}