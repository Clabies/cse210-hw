using System;

record RequestDTO(
    string GoalType,
    string ShortName,
    string Description,
    string Points,
    int Bonus,
    int Target,
    int AmountCompleted,
    bool IsComplete
)
{
    public static RequestDTO ToRequestDTO(Goal goal)
    {
        return new RequestDTO(
            goal.GetType().Name,
            goal.GetName(),
            goal.GetDescription(),
            goal.GetPoints(),
            goal.GetBonus(),
            goal.GetTarget(),
            goal.GetAmountCompleted(),
            goal.IsComplete()
        );
    }
}