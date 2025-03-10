using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one player and one empty room
            Console.Write("Please enter your characters name: ");
            string name = Console.ReadLine();

            player = new Player(name, 100);
            currentRoom = new Room(0);
        }

        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                bool choosing = true;
                while (choosing)
                {
                    Console.Write("Enter input here: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "look":
                            Console.WriteLine(currentRoom.GetDescription());
                            break;
                        case "search":
                            currentRoom.GetLoot();
                            break;
                        case "stats":
                            Console.WriteLine($"Name: {player.Name} \nHealth: {player.Health}");
                            break;
                        case "proceed":
                            choosing = false;
                            break;
                        case "exit":
                            if (currentRoom.GetTitle() == "Exit Room")
                            {
                                Console.WriteLine("escaped!");
                            }
                            else
                            {
                                Console.WriteLine("there is no exit here!");
                            }
                            break;
                        case "quit":
                            Console.WriteLine("quit button here...");
                            break;
                        case "help":
                            Console.WriteLine("commands are: look, search, stats, proceed, exit, quit and help...");
                            break;
                        default:
                            Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                            break;
                    }
                }

                // Generate a number between 0 and 99 to use for creating the next room
                Random randomNum = new Random();
                int seed = randomNum.Next(0, 100);
                currentRoom = new Room(seed);
            }
        }
    }
}