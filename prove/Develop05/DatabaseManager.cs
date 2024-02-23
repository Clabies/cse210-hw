using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class DatabaseManager
{
    public static void SaveData(string dbName, int score, List<RequestDTO> listDTO)
    {
        Console.WriteLine("Saving your data ...");
        using (StreamWriter writer = new StreamWriter(dbName))
        {
            writer.WriteLine($"\"{score}\"");
            foreach (RequestDTO req in listDTO)
            {
                string serializedReq = $"{req.GoalType},{req.ShortName},{req.Description},{req.Points},{req.Bonus},{req.Target},{req.AmountCompleted},{req.IsComplete}";
                writer.WriteLine(serializedReq);
            }
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your data is now saved!");
        Thread.Sleep(2000);
    }

    public static ResponseDTO LoadData(string dbName)
    {
        List<RequestDTO> listDTO = new List<RequestDTO>();

        Console.WriteLine("Loading your data ...");
        string[] allLines = File.ReadAllLines(dbName);

        int score = int.Parse(allLines[0]);

        for (int i = 1; i < allLines.Length; i++)
        {
            string[] reqData = allLines[i].Split(',');
            RequestDTO req = new RequestDTO(reqData[0], reqData[1], reqData[2], reqData[3], int.Parse(reqData[4]), int.Parse(reqData[5]), int.Parse(reqData[6]), bool.Parse(reqData[7]));
            listDTO.Add(req);
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your data is now loaded!");
        Thread.Sleep(2000);
        return new ResponseDTO(score, listDTO);
    }
}