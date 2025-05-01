using System;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Monster currentMonster;
        bool playing = true;

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
                    currentRoom = new EmptyRoom();
                    nameValidation = false;
                }
            }
        }

        public void Start()
        {
            // Create gameplay loop until the user quits or escapes
            while (playing)
            {     
                // Get user choice and perform appropriate action
                Console.Write("\nEnter input here: ");
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
                        CheckForMonsters();
                        break;
                    case "stats":
                        Console.WriteLine($"Name: {player.Name} \nHealth: {player.Health}");
                        break;
                    case "inventory":
                        player.OpenInventory();
                        break;
                    case "proceed":

                        if (currentRoom.CurrentMonsterNum > 0)
                        {
                            Console.WriteLine("A shadowy figure blocks your path!");
                        }
                        else
                        {
                            Console.WriteLine("===========================================\n");
                            GenerateRoom();
                        }
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
                        Console.WriteLine("commands are: look, search, attack, stats, inventory, proceed, leave and quit");
                        break;
                    default:
                        Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                        break;
                    }
                
            }
        }

        public void GenerateRoom()
        {
            int randomNum = RNG();
            if (randomNum >= 90)
            {
                currentRoom = new ExitRoom();
            }
            else if (randomNum >= 60)
            {
                currentRoom = new TreasureRoom();
            }
            else
            {
                currentRoom = new EmptyRoom();
            }
        }

        public static int RNG()
        {
            // Generate a number between 0 and 99
            Random randomNum = new Random();
            return randomNum.Next(0, 100);
        }

        public void CheckForMonsters()
        {
            if (currentRoom.CurrentMonsterNum > 0)
            {
                GenerateMonster();
                AttackSequence();
            }
            else
            {
                Console.WriteLine("There isn't any monsters to attack...");
            }

        }

        public void GenerateMonster()
        {
            int randomNum = RNG();
            if (randomNum >= 90)
            {
                currentMonster = new Orc();
            }
            else if (randomNum >= 60)
            {
                currentMonster = new FallenKnight();
            }
            else if (randomNum >= 30)
            {
                currentMonster = new Skeleton();
            }
            else
            {
                currentMonster = new Goblin();
            }
        }

        public void AttackSequence()
        {
            Console.WriteLine($"A {currentMonster.Name} Appeared!");

            bool attackLoop = true;
            while (attackLoop)
            {
                bool choiceLoop = true;
                while (choiceLoop)
                {
                    Console.Write("\nBattle input: ");
                    string choice = Console.ReadLine().ToLower().Trim();

                    switch (choice)
                    {
                        case "attack":
                            Console.WriteLine("You attacked!");
                            choiceLoop = false;
                            break;
                        case "inventory":
                            player.OpenInventory();
                            break;
                        case "flee":
                            Console.WriteLine("You fled the battle!");
                            currentRoom.CurrentMonsterNum -= 1;
                            choiceLoop = false;
                            attackLoop = false;
                            break;
                        case "help":
                            Console.WriteLine("commands are: attack, inventory and flee ");
                            break;
                        default:
                            Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                            break;
                    }
                }

                int playerDamageDealt = player.Attack(player.GetMaxDamageVariance());
                currentMonster.Health -= playerDamageDealt;

                float monsterDamageDealt = currentMonster.Attack(currentMonster.GetMaxDamageVariance());
                float armourDefense = Player.GetPlayerEquippedArmourDefense();
                player.Health -= (int)Math.Round(monsterDamageDealt * armourDefense);

                Console.WriteLine("################################################");
                Console.WriteLine($"currentMonster.Health: {currentMonster.Health}");
                Console.WriteLine($"player.Health: {player.Health}");

                if (currentMonster.Health <= 0)
                {
                    attackLoop = false;
                    Console.WriteLine($"{currentMonster.Name} defeated!");
                }

                if (player.Health <= 0)
                {
                    attackLoop = false;
                    playing = false;
                    Console.WriteLine("Game over!");
                }
            }
        }   
    }
}