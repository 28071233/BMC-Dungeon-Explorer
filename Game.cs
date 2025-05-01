using System;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Merchant merchant;
        public Room currentRoom;
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
                // Get user choice...
                Console.Write("\nRoom Input: ");
                string choice = Console.ReadLine().ToLower().Trim();

                // ...and then perform appropriate action
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
                    case "trade":
                        CheckForMerchant();
                        break;
                    case "stats":
                        Console.WriteLine($"Name: {player.Name} \nHealth: {player.Health}");
                        break;
                    case "inventory":
                        player.OpenInventory();
                        break;
                    case "proceed":
                        // Check if current room contains any monsters
                        // if there is a monster present the user will not be able to proceed until it is defeated
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
                        Console.WriteLine("commands are: look, search, attack, trade, stats, inventory, proceed, leave and quit");
                        break;
                    default:
                        Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                        break;
                    }
                
            }
        }

        // Function is responsible for selecting the next room to load into the currentRoom field
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
            else if (randomNum >= 40)
            {
                currentRoom = new MerchantRoom();
            }
            else
            {
                currentRoom = new EmptyRoom();
            }
        }

        // Function is responsible for randomness throughout the code
        public static int RNG()
        {
            // Generate a number between 0 and 99
            Random randomNum = new Random();
            return randomNum.Next(0, 100);
        }

        // checks if there is any monsters in the room...
        public void CheckForMonsters()
        {
            // ...and if there's at least one monster in the room... 
            if (currentRoom.CurrentMonsterNum > 0)
            {
                // ...a monster is loaded into the current monster field...
                GenerateMonster();
                // ...and then the attack sequence begins
                AttackSequence();
            }
            else
            {
                Console.WriteLine("There isn't any monsters to attack...");
            }
        }

        // checks if the current room is a merchant room...
        public void CheckForMerchant()
        {
            if (currentRoom.Title == "Merchant Room")
            {
                // ...if it is then a new merchant is created...
                merchant = new Merchant();
                // ..and the trading window is opened
                TradeSequence();
            }
            else
            {
                Console.WriteLine("There's no one to trade with!");
            }
        }

        // loads a new monster into the currentMonster Field depending on RNG
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

        // allows the player to trade with the current merchant
        public void TradeSequence()
        {
            // display the current merchants inventory
            merchant.InventoryContents();

            // keep player in trade window until they choose to back out of it
            bool tradeLoop = true;
            while (tradeLoop)
            {
                // Get user choice...
                Console.Write("\nTrade input: ");
                string choice = Console.ReadLine().ToLower().Trim();

                // ...split the inputs into two...
                string[] inputs = choice.Split(' ');

                // ...and then perform appropriate action
                switch (inputs[0])
                {
                    case "buy":
                        try
                        {
                            merchant.SellItem(inputs[1]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("you must select a valid item to buy!");
                        }
                        break;
                    case "sell":
                        try
                        {
                            merchant.BuyItem(inputs[1]);
                        }
                        catch (System.InvalidOperationException)
                        {
                            Console.WriteLine("i do not know how to prevent this error");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You must choose a valid item to sell!");
                        }
                        break;
                    case "items":
                        Console.WriteLine("items here");
                        break;
                    case "back":
                        tradeLoop = false;
                        break;
                    case "help":
                        Console.WriteLine("commands are: buy, sell, items and back ");
                        break;
                    default:
                        Console.WriteLine("Invalid option, type \"help\" for a list of commands...");
                        break;
                }
            }
        }

        // allows the player to battle the current monster
        public void AttackSequence()
        {
            // introduce the current monster
            Console.WriteLine($"A {currentMonster.Name} Appeared!");

            // create a loop that allows the battle to go for multiple turns
            bool attackLoop = true;
            while (attackLoop)
            {
                // create a loop for the user until they choose to flee or attack
                bool choiceLoop = true;
                while (choiceLoop)
                {
                    // Get user choice...
                    Console.Write("\nBattle input: ");
                    string choice = Console.ReadLine().ToLower().Trim();

                    // ...and then perform appropriate action
                    switch (choice)
                    {
                        case "attack":
                            // retrieve the damage from the players current weapon + or - some random number...
                            int playerDamageDealt = player.Attack(player.GetMaxDamageVariance());
                            // ...then subtract that from the current monsters health
                            currentMonster.Health -= playerDamageDealt;

                            // retrieve the base attack damage from the current monster + or - some random number...
                            float monsterDamageDealt = currentMonster.Attack(currentMonster.GetMaxDamageVariance());
                            // ...then retrieve the players armour defense value...
                            float armourDefense = Player.GetPlayerEquippedArmourDefense();
                            // ...and then use that value to shield the player from some of the damage cause by the current monster
                            player.Health -= (int)Math.Round(monsterDamageDealt * armourDefense);
                            // finally leave the loop to check if the player or monster has died
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

                // Display current battle stats
                Console.WriteLine("################################################");
                Console.WriteLine($"{currentMonster.Name} Health: {currentMonster.Health}");
                Console.WriteLine($"your health: {player.Health}");

                // Check if the current monster is dead, if so leave the attack sequence and continue 
                if (currentMonster.Health <= 0)
                {
                    attackLoop = false;
                    Console.WriteLine($"{currentMonster.Name} defeated!");
                }

                // Check if the player is dead, if so leave the attack sequence and game and then display a game over screen
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