using System;
using PSN.NET;

namespace PSNExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Game Content ID, Game Region and User Age");
            string ContentID = Console.ReadLine(); 
            string Region = Console.ReadLine();
            string age = Console.ReadLine();

            ChihiroAPIClient client = new ChihiroAPIClient();
            PSNItem game = client.GetItem(ContentID, Region, age);

            Console.WriteLine($"Game Title: {game.TitleName}");
            Console.WriteLine($"Game Revision: {game.Revision}");
            Console.WriteLine($"Game Size: {game.Size}");

            Console.WriteLine("");

            Console.ReadLine();
            
        }
    }
}
