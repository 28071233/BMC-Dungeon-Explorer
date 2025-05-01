using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public virtual string Name { get; set; }
        public abstract string Description { get; }
        public virtual int Health { get; set; }
    }

    public class Merchant : Creature
    {
        public override string Name => "Merchant";
        public override string Description => "An old Wizard behind a crooked table with strange items";
        public override int Health => 1;
        public static List<(string item, int amount)> inventory = new List<(string item, int amount)>();

        // initialise merchant with their items
        public Merchant()
        {
            inventory.Add(("HealthFlask", 1));
            inventory.Add(("WornSword", 1));
        }

        // display the merchants items
        public void InventoryContents()
        {
            Console.WriteLine("\nMerchant Inventory");
            Console.WriteLine("============================");
            // display each item and it's amount for each row
            foreach ((string item, int amount) pair in inventory)
            {
                Console.WriteLine($"{pair.item}: {pair.amount}");
            }
            Console.WriteLine("============================");
        }

        // allows the merchant to sell items to the player
        public void SellItem(string item)
        {
            // check if the item the user inputted is in the merchants inventory...
            bool merchantItemFound = false;
            foreach ((string item, int amount) merchantPair in inventory)
            {
                // ...if it's present attempt to buy it...
                if (merchantPair.item.ToLower() == item)
                {
                    merchantItemFound = true;
                    Gold gold = new Gold();
                    gold.UseItem();
                }
            }

            // ...otherwise inform the user that the merchant doesn't have that item for sale
            if (merchantItemFound == false)
            {
                Console.WriteLine($"The merchant isn't selling any {item}");
            }
        }

        // allows the merchant to buy items to the player
        public void BuyItem(string item)
        {
            // check if the item the player inputted is in the players inventory..
            bool playerItemFound = false;
            foreach ((string item, int amount) playerPair in Player.inventory)
            {
                if (playerPair.item.ToLower() == item)
                {
                    // ...if it's present attempt to sell it...
                    playerItemFound = true;
                    Console.WriteLine($"You sold a {item}");
                    Player.RemoveItem(item);
                    Player.PickUpItem("Gold");
                }
            }

            // ...otherwise inform the user that the player doesn't have that item to sell
            if (playerItemFound == false)
            {
                Console.WriteLine($"You dont have a {item} to sell!");
            }
        }
    }

    public abstract class Monster : Creature, IAttack
    {
        public abstract int AttackBaseDamage { get; }
        public abstract int lootChance { get; }

        // function is used to make the damage from the monster vary by 50%
        public int GetMaxDamageVariance()
        {
            int maxDamageVariance = (this.AttackBaseDamage / 2);
            return maxDamageVariance;
        }

        // function enables the monsters in sub classes to attack the player
        public int Attack(int maxDamageVariance)
        {
            // set up variables...
            Random randomNum = new Random();
            int damageDealt;

            // ...then generate a random number between 0.00 and 0.99...
            float randomDamageVariance = randomNum.Next(0, 100);
            float damageVariance = randomDamageVariance / 100;

            // ...then calculate how much the damage can vary...
            float calculatedDamageVariance = maxDamageVariance * damageVariance;
            calculatedDamageVariance = (float)Math.Round(calculatedDamageVariance);

            // ..then choose to add or subtract this variance to the base attack damage...
            int addOrSubtractDamage = randomNum.Next(0, 100);

            if (addOrSubtractDamage >= 50)
            {

                damageDealt = (int)(this.AttackBaseDamage + calculatedDamageVariance);
                return damageDealt;
            }
            else
            {
                damageDealt = (int)(this.AttackBaseDamage - calculatedDamageVariance);
                return damageDealt;
            }
            // ...finally return this value
        }

        public abstract void SpecialAttack();

        public abstract void Flee();
    }

    public class Goblin : Monster
    {
        public override string Name => "Goblin";
        public override string Description => "A small but agile creature looking for treasures";
        public override int AttackBaseDamage => 15;
        public override int lootChance => 100;

        public Goblin()
        {
            this.Health = 50;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("The Goblin used it's special attack!");
        }

        public override void Flee()
        {
            Console.WriteLine("The Goblin fled the battle!");
        }
    }

    public class Skeleton : Monster
    {
        public override string Name => "Skeleton";
        public override string Description => "A slender, decomposed adventurer wielding a bow";
        public override int AttackBaseDamage => 25;
        public override int lootChance => 30;

        public Skeleton()
        {
            this.Health = 70;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("The Skeleton used it's special attack!");
        }

        public override void Flee()
        {
            Console.WriteLine("The Skeleton fled the battle!");
        }
    }

    public class FallenKnight : Monster
    {
        public override string Name => "Fallen Knight";
        public override string Description => "A decrepit suit of armour that continues to fight long after it's master has fallen";
        public override int AttackBaseDamage => 30;
        public override int lootChance => 50;

        public FallenKnight()
        {
            this.Health = 100;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("The Fallen Knight used it's special attack!");
        }

        public override void Flee()
        {
            Console.WriteLine("The Fallen Knight fled the battle!");
        }
    }

    public class Orc : Monster
    {
        public override string Name => "Orc";
        public override string Description => "A towering beast that weaponises whatever crude object it gets it's hands on";
        public override int AttackBaseDamage => 20;
        public override int lootChance => 15;

        public Orc()
        {
            this.Health = 150;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("The Orc uses it's special attack!");
        }

        public override void Flee()
        {
            Console.WriteLine("The Orc fled the battle!");
        }
    }

    public class Player : Creature, IAttack//, IInventory (couldn't implement due to static variables)
    {
        public override string Description => "An underprepared adventurer wishing to test their luck";
        public static string EquippedArmour = "RustyArmour";
        public static string EquippedWeapon = "RustySword";
        public static List<(string item, int amount)> inventory = new List<(string item, int amount)>();

        public Player(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }

        public static int GetPlayerEquippedWeaponDamage()
        {
            switch (EquippedWeapon) 
            {
                case "RustySword":
                    RustySword rustySword = new RustySword();
                    return rustySword.AttackBaseDamage;
                case "WornSword":
                    WornSword wornSword = new WornSword();
                    return wornSword.AttackBaseDamage;
                default:
                    return 0;
            }
        }

        public static float GetPlayerEquippedArmourDefense()
        {
            switch (EquippedArmour)
            {
                case "RustyArmour":
                    RustyArmour RustyArmour = new RustyArmour();
                    return RustyArmour.ArmourBaseDefense;
                case "WornArmour":
                    WornArmour WornArmour = new WornArmour();
                    return WornArmour.ArmourBaseDefense;
                default:
                    return -1;
            }
        }

        public int GetMaxDamageVariance()
        {
            int maxDamageVariance = (Player.GetPlayerEquippedWeaponDamage() / 2);
            return maxDamageVariance;
        }

        public int Attack(int maxDamageVariance)
        {
            Random randomNum = new Random();
            int damageDealt;

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

                damageDealt = (int)(Player.GetPlayerEquippedWeaponDamage() + calculatedDamageVariance);
                return damageDealt;
            }
            else
            {
                damageDealt = (int)(Player.GetPlayerEquippedWeaponDamage() - calculatedDamageVariance);
                return damageDealt;
            }
        }

        public static void PickUpItem(string item)
        {
            bool itemFound = false;
            foreach ((string item, int amount) pair in inventory)
            {
                if (pair.item == item)
                {
                    itemFound = true;

                    int changeAmount = pair.amount;
                    changeAmount += 1;
                    inventory.Remove((item, pair.amount));
                    inventory.Add((item, changeAmount));

                    break;
                }
            }

            if (itemFound == false)
            {
                inventory.Add((item, 1));
            }
        }

        public static void RemoveItem(string item)
        {
            foreach ((string item, int amount) pair in inventory)
            {
                if (pair.item == item)
                {
                    if (pair.amount == 1)
                    {
                        inventory.Remove((pair.item, 1));
                        break;
                    }
                    else
                    {
                        int changeAmount = pair.amount;
                        changeAmount -= 1;
                        inventory.Remove((item, pair.amount));
                        inventory.Add((item, changeAmount));
                        break;
                    }
                }
            }
        }

        public void OpenInventory()
        {
            InventoryContents();

            bool inventoryLoop = true;
            while (inventoryLoop)
            {
                Console.Write("\nInventory: ");
                string choice = Console.ReadLine().ToLower().Trim();

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
                        InventoryContents();
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
        }

        public void InventoryContents()
        {
            Console.WriteLine("\nInventory");
            Console.WriteLine("============================");
            foreach ((string item, int amount) pair in inventory)
            {
                Console.WriteLine($"{pair.item}: {pair.amount}");
            }
            Console.WriteLine("============================");
        }
    }
}

