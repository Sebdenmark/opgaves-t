using System;

namespace ConsoleApp1
{
    class Program
    {
        //here are my main i have placed them in there own file so that you call the methods in the main but keeps the main short
        //I have used a while loop here so that if you die in the game ore if you win you get the change to try again
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Game game = new Game();
                game.Start();

                Console.WriteLine("Do you want to play again? (yes/no)");
                string response = Console.ReadLine().ToLower();
                playAgain = response == "yes";
            }

            Console.WriteLine("Thank you for playing Dungeon Escape! Goodbye.");
            Console.ReadLine();
        }
    }
}