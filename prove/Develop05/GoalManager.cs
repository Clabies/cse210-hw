using System;
using System.Collections.Generic;

class GoalManager
{
    private List<Goal> _objectives;
    private int _totalScore;

    public GoalManager()
    {
        _objectives = new List<Goal>();
        _totalScore = 0;
    }

    public void Start()
    {
        string menu =
        $@"
        Menu Options:
            1. Create New Goal
            2. List Goals
            3. Save Goals
            4. Load Goals
            5. Record Event
            6. Quit
        Select a choice from the menu: ";

        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.Write(menu);

            string input = Console.ReadLine();
            if (input == "6")
            {
                break;
            }
            else if (input == "1")
            {
                CreateGoal();
            }
            else if (input == "2")
            {
                ListObjectiveDetails();
            }
            else if (input == "3")
            {
                SaveGoals();
            }
            else if (input == "4")
            {
                LoadGoals();
            }
            else if (input == "5")
            {
                RecordEvent();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_totalScore} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _objectives.Count; i++)
        {
            int order = i + 1;
            string represent = _objectives[i].GetStringRepresentation();
            Console.WriteLine($"{order}. {represent}");
        }
    }

    public void ListObjectiveDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _objectives.Count; i++)
        {
            int order = i + 1;
            Console.WriteLine($"{order}. {_objectives[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        string createGoalMenu =
        @"
        The types of Goals are:
            1. Simple Goal
            2. Eternal Goal
            3. Checklist Goal
        Which type of goal would you like to create? ";

        Console.WriteLine(createGoalMenu);
        string typeOfGoal = Console.ReadLine();

        switch (typeOfGoal)
        {
            case "1":
                Goal simpleObjective = new SimpleGoal("", "", "");
                simpleObjective.GetDetailsString();
                _objectives.Add(simpleObjective);
                break;

            case "2":
                Goal eternalObjective = new EternalGoal("", "", "");
                eternalObjective.GetDetailsString();
                _objectives.Add(eternalObjective);
                break;

            case "3":
                Goal checklistObjective = new ChecklistGoal("", "", "", -1, -1);
                checklistObjective.GetDetailsString();
                _objectives.Add(checklistObjective);
                break;

            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("What goal did you accomplish? ");
        int indexGoal = int.Parse(Console.ReadLine()) - 1;
        Goal goalSelected = _objectives[indexGoal];
        Console.WriteLine();

        if (!goalSelected.IsComplete())
        {
            _totalScore += int.Parse(goalSelected.GetPoints());
        }

        goalSelected.RecordEvent();
        Console.WriteLine($"You now have {_totalScore} points");
    }

    public void SaveGoals()
    {
        List<RequestDTO> listReqDTO = new List<RequestDTO>();
        foreach (Goal goal in _objectives)
        {
            listReqDTO.Add(RequestDTO.ToRequestDTO(goal));
        }

        Console.Write("Enter the filename for the goal file: ");
        string DBName = Console.ReadLine();
        DatabaseManager.SaveData(DBName, _totalScore, listReqDTO);
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string DBName = Console.ReadLine();
        ResponseDTO managerToLoad = DatabaseManager.LoadData(DBName);
        _totalScore = managerToLoad.Score;
        List<RequestDTO> listOfDTOs = managerToLoad.RequestDTOList;
        foreach (RequestDTO goalDTO in listOfDTOs)
        {
            _objectives.Add(Goal.ConvertToGoal(goalDTO));
        }
    }
}