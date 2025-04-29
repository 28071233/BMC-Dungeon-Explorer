using System;
using System.Media;

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
                        player.InventoryContents();
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
                    Console.Write("\nEnter input here: ");
                    string choice = Console.ReadLine().ToLower().Trim();

                    switch (choice)
                    {
                        case "attack":
                            Console.WriteLine("You attacked!");
                            choiceLoop = false;
                            break;
                        case "inventory":
                            Console.WriteLine("Inventory menu");
                            player.InventoryContents();

                            bool inventoryLoop = true;
                            while (inventoryLoop)
                            {
                                Console.Write("\nEnter input here: ");
                                choice = Console.ReadLine().ToLower().Trim();

                                string[] inputs = choice.Split(' ');
                                switch (inputs[0])
                                {
                                    case "use":
                                        try
                                        {
                                            switch (inputs[1])
                                            {
                                                case "gold":
                                                    Gold gold = new Gold();
                                                    gold.UseItem();
                                                    break;
                                                case "healthflask":
                                                    HealthFlask healthFlask = new HealthFlask();
                                                    healthFlask.UseItem();
                                                    break;
                                                case "rope":
                                                    Rope rope = new Rope();
                                                    rope.UseItem();
                                                    break;
                                                default:
                                                    Console.WriteLine("You must choose a valid item to Use!");
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("You must choose an item to use!");
                                        }
                                        break;
                                    case "define":
                                        try
                                        {
                                            switch (inputs[1])
                                            {
                                                case "gold":
                                                    Gold gold = new Gold();
                                                    gold.GetDescription();
                                                    break;
                                                case "healthflask":
                                                    HealthFlask healthFlask = new HealthFlask();
                                                    healthFlask.GetDescription();
                                                    break;
                                                case "rope":
                                                    Rope rope = new Rope();
                                                    rope.GetDescription();
                                                    break;
                                                default:
                                                    Console.WriteLine("You must choose a valid item to Define!");
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("You must choose an item to use!");
                                        }
                                        break;
                                    case "back":
                                        inventoryLoop = false;
                                        break;
                                    case "inventory":
                                        player.InventoryContents();
                                        break;
                                    case "help":
                                        Console.WriteLine("commands are: use, define and back followed by item name or inventory");
                                        Console.WriteLine("Example: \"use healthflask\"");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                                        break;

                                }
                            }
                            break;
                        case "flee":
                            Console.WriteLine("You fled the battle!");
                            choiceLoop = false;
                            break;
                        case "help":
                            Console.WriteLine("commands are: attack, inventory and flee ");
                            break;
                        default:
                            Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                            break;
                    }
                }

                CalculateMonsterDamage();

                if (player.Health <= 0)
                {
                    attackLoop = false;
                    playing = false;
                    Console.WriteLine("Game over!");
                }
            }
        }   

        public void CalculateMonsterDamage()
        {
            Random randomNum = new Random();
            int damageDealt;

            int maxDamageVariance = (currentMonster.AttackBaseDamage / 2);

            float randomDamageVariance = randomNum.Next(0, 100);
            float damageVariance = randomDamageVariance / 100;

            float calculatedDamageVariance = maxDamageVariance * damageVariance;
            calculatedDamageVariance = (float)Math.Round(calculatedDamageVariance);

            int addOrSubtractDamage = randomNum.Next(0, 100);

            if (addOrSubtractDamage >= 50)
            {
                /*
                    Thoughts things
                    - if base attack damage is 20, the max attack varience is 10
                    - meaning the lowest attack is 10 and the highest is 30
                    - if rng is above or equal to 50 we add, otherwise we takeaway
                    - we can use rng again to generate a percentage represented as a number from 0.00 to 0.99, 
                    - using this we can calculate the damage varience by doing: 
                    randomNum = RNG()
                    float damageVariance = randomNum / 100
                    - Finally we can calculate the damage dealt:
                    int damageDealt = currentMonster.AttackBaseDamage (+ or -) (maxDamageVariance * damageVariance)
                */

                damageDealt = (int)(currentMonster.AttackBaseDamage + calculatedDamageVariance);
                player.Health -= damageDealt;
            }
            else
            {
                damageDealt = (int)(currentMonster.AttackBaseDamage - calculatedDamageVariance);
                player.Health -= damageDealt;
            }

            Console.WriteLine("\n=====================================");
            Console.WriteLine("Debug\n");
            Console.WriteLine($"Name: {currentMonster.Name}");
            Console.WriteLine($"addOrSubtractDamage: {addOrSubtractDamage}");
            Console.WriteLine($"AttackBaseDamage: {currentMonster.AttackBaseDamage}");
            Console.WriteLine($"maxDamageVariance: {maxDamageVariance}");
            Console.WriteLine($"randomDamageVariance: {randomDamageVariance}");
            Console.WriteLine($"damageVariance: {damageVariance}");
            Console.WriteLine($"calculatedDamageVariance: {calculatedDamageVariance}");
            Console.WriteLine($"damageDealt: {damageDealt}");
            Console.WriteLine($"player.Health: {player.Health}");
        }
    }
}