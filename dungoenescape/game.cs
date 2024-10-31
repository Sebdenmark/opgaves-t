using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Game
    {
        //here is my verbals i have put them right in the class so they can get accesed by all of the methods 
        private char[,] maze;
        private int playerX, playerY;
        private int keyX, keyY;
        private bool hasKey = false;
        private bool gameRunning = true;
        private readonly (int x, int y)[] traps;  // i use this array to store hidden traps 

        //this is the method for buliding and setting up the game
        public Game()
        {
            // here i have made the maze with no visbel traps or key
            maze = new char[5, 5]
            {
                {'S', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', 'E'},
                {'.', '.', '.', '.', '.'}
            };

            playerX = 0;
            playerY = 0;

            // here you define the key location and the traps location, by using x,y, i have done it like this so i can hide them and make the game harder 
            keyX = 2;
            keyY = 2;
            traps = new (int x, int y)[] { (0, 3), (1, 1), (3, 1) };  
        }

        //this is the method for the start and the movement. i use a switch case here to make it more simpel, you could use if, else also
        public void Start()
        {
            Console.WriteLine("Dungeon Escape!");
            Console.WriteLine("Your have to find the hidden key and reach the exit that is marked as (E).");
            Console.WriteLine("to move you have to write 'up', 'down', 'left', 'right' to move.");

            while (gameRunning)
            {
                PrintMaze();
                Console.Write("Enter where you like to go: ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    default:
                        Console.WriteLine("Invalid command. Use 'up', 'down', 'left', 'right'.");
                        break;
                }
            }
        }


        //this is the method that tracks and cheks the players movement 
        //newX and newY are calculated based on the player’s current position,deltaX and deltaY determine how far and in which direction the player moves
        // the method also cheks The method checks if the player are within the maze boundaries to ensure the player doesn't go outside the maze.
        //aswell as it checks for that the player walks in to a trap with and if statement, and if the player finds the key with.
        // it also makes sure that the player only can win if they find the key and get to the exit
        private void Move(int deltaX, int deltaY)
        {
            int newX = playerX + deltaX;
            int newY = playerY + deltaY;

            if (newX >= 0 && newX < maze.GetLength(0) && newY >= 0 && newY < maze.GetLength(1))
            {
                playerX = newX;
                playerY = newY;

                if (playerX == keyX && playerY == keyY && !hasKey)
                {
                    hasKey = true;
                    Console.WriteLine("The hidden key! Good job! Now find the exit.");
                    Console.ReadLine();
                }

                foreach (var (x, y) in traps)
                {
                    if (playerX == x && playerY == y)
                    {
                        Console.WriteLine("You fell into a trap and died! Game over.");
                        Console.ReadLine();
                        gameRunning = false;
                        return;
                    }
                }

                char cell = maze[playerX, playerY];

                switch (cell)
                {
                    case 'E':
                        if (hasKey)
                        {
                            Console.WriteLine("Congrats! You escaped the dungeon.");
                            gameRunning = false;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You need the key to exit.");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("empty room keep looking.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("You hit a wall. Try another way.");
                Console.ReadLine();
            }
        }

        //This method visually updates the maze showing only the players position and the exit while keeping traps and the key hidden
        //this method uses loops to go through each position in the maze x loop: Moves row by row vertical.y loop: Moves column by column within each row horizontal.
        //it displays as p and replaces the field it moves to with that so you can see where you are going
        private void PrintMaze()
        {
            Console.Clear();
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (x == playerX && y == playerY)
                        Console.Write("P ");
                    else if (maze[x, y] == 'E')  // Only show the exit
                        Console.Write(maze[x, y] + " ");
                    else
                        Console.Write(". ");  // Display empty rooms and keep traps and key hidden
                }
                Console.WriteLine();
            }
        }
    }
}
