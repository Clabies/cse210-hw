using System;

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Distance in miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / base.lengthInMinutes) * 60; // Speed in mph
    }

    public override double GetPace()
    {
        return base.lengthInMinutes / GetDistance();
    }
}