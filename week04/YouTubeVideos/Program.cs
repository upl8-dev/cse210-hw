using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Early Parenthood Tips and Tricks", "Parenting Expert", 600);
        video1.AddComment(new Comment("Richard", "This is so relatable!"));
        video1.AddComment(new Comment("Cheryl", "Fantastic explanation. Thanks for sharing!"));
        video1.AddComment(new Comment("Sally", "Please make more videos like this. I didn't know I needed this until I watched it."));

        Video video2 = new Video("Beginner's Guide to Game Development", "Game Dev Studio", 840);
        video2.AddComment(new Comment("Ivan", "I want to make my own game now. Thanks for the inspiration!"));
        video2.AddComment(new Comment("David", "The examples were very simple to understand. Great for beginners!"));
        video2.AddComment(new Comment("Aly", "This is exactly what my son has been asking about. Thanks!"));
        video2.AddComment(new Comment("Josh", "I appreciate the encouragement to start with small projects and learn as I go."));


        Video video3 = new Video("Top 5 Habits", "Simple Wins", 620);
        video3.AddComment(new Comment("Gracie", "These habits have changed my life!"));
        video3.AddComment(new Comment("Noah", "Very practical advice. I appreciate the focus on small, actionable steps."));
        video3.AddComment(new Comment("Ryan", "I love how you emphasized consistency over perfection. That's so important!"));
        video3.AddComment(new Comment("Daniel", "This video is a great reminder that small changes can lead to big results. Thanks for sharing!"));


        Video video4 = new Video("Cooking for Beginners", "Cooking with Sarah", 420);
        video4.AddComment(new Comment("John", "Thank you for the helpful tips! I feel more confident in the kitchen now."));
        video4.AddComment(new Comment("Alex", "This video is a game-changer for me. I always struggled with cooking, but now I feel like I can actually do it!"));
        video4.AddComment(new Comment("Sophia", "I love how you broke down the cooking process into simple steps."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._commenterName}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}