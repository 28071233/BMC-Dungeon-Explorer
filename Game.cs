using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private RoomRewritten CurrentRoomRewritten;

        public Game()
        {
            bool nameValidation = true;
            while (nameValidation)
            {
                Console.Write("Please enter your characters name: ");
                string name = Console.ReadLine();
                
                //Check input to check if the name is valid
                if (string.IsNullOrWhiteSpace(name)) {
                    Console.WriteLine("name cannot be empty!");
                }
                else
                {
                    //Initialize the game with one player and one empty room
                    player = new Player(name, 100);
                    currentRoom = new Room(0);
                    nameValidation = false;
                }
            }
        }

        public void Start()
        {
            // Create gameplay loop until the user quits or escapes
            bool playing = true;
            while (playing)
            {     
                // Get user choice and perform appropriate action
                Console.Write("Enter input here: ");
                string choice = Console.ReadLine().ToLower().Trim();

                switch (choice)
                {
                    case "look":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "search":
                        currentRoom.GetLoot();
                        break;
                    case "attack":
                        Console.WriteLine("attack logic here");
                        break;
                    case "stats":
                        Console.WriteLine($"Name: {player.Name} \nHealth: {player.Health}");
                        break;
                    case "inventory":
                        Player.InventoryContents();
                        break;
                    case "proceed":
                        Console.WriteLine("===========================================\n");
                        GenerateRoom();
                        break;
                    case "leave":
                        if (currentRoom.GetTitle() == "Exit Room")
                        {
                            playing = false;
                            Console.WriteLine("Congratulations you escaped!");
                        }
                        else
                        {
                            Console.WriteLine("there is no exit here!");
                        }
                        break;
                    case "quit":
                        playing = false;
                        break;
                    case "help":
                        Console.WriteLine("commands are: look, search, attack, stats, inventory, proceed, leave, quit and help...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                        break;
                    }
                
            }
        }

        public void GenerateRoom()
        {
            currentRoom = new Room(RNG());

            int roomSeed = RNG();
            if (roomSeed >= 90)
            {
                CurrentRoomRewritten = new ExitRoom();
            }
            else if (roomSeed >= 60)
            {
                CurrentRoomRewritten = new TreasureRoom();
            }
            else
            {
                CurrentRoomRewritten = new EmptyRoom();
            }
        }

        public static int RNG()
        {
            // Generate a number between 0 and 99
            Random randomNum = new Random();
            return randomNum.Next(0, 100);
        }
    }
}