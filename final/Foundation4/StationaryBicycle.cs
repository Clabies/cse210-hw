using System;

public class StationaryBicycle : Activity
{
    private double speed;

    public StationaryBicycle(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * base.lengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}