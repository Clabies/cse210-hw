using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        Video video1 = new Video { Title = "First Video", Author = "John Doe", Length = 120 };
        video1.AddComment("Alice", "Great video!");
        video1.AddComment("Bob", "I learned a lot from this.");

        Video video2 = new Video { Title = "Second Video", Author = "Jane Smith", Length = 180 };
        video2.AddComment("Charlie", "Nice content!");

        Video video3 = new Video { Title = "Third Video", Author = "Mike Johnson", Length = 150 };
        video3.AddComment("Emily", "I have a question about this.");

        // Putting videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}