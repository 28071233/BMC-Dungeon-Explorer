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

        /*public Merchant(string name, string description, int health) 
            : base(name, description, health)
        {
            this.Name = name;
            this.Description = description;
            this.Health = health;
        }*/

        public void DisplayItems()
        {

        }

        public void SellItems()
        {

        }

        public void BuyItems()
        {

        }

    }

    public abstract class Monster : Creature
    {
        public abstract int AttackBaseDamage { get; }
        public abstract bool Hasloot { get; }

        public abstract void Attack();

        public abstract void SpecialAttack();

        public abstract void Flee();
    }

    public class Goblin : Monster
    {
        public override string Name => "Goblin";
        public override string Description => "A small but agile creature looking for treasures";
        public override int Health => 50;
        public override int AttackBaseDamage => 15;
        public override bool Hasloot => true;

        public Goblin()
        {
            this.Health = 50;
        }

        public override void Attack()
        {
            Console.WriteLine("The Goblin attacks!");
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
        public override int Health => 70;
        public override int AttackBaseDamage => 25;
        public override bool Hasloot => false;

        public Skeleton()
        {
            this.Health = 70;
        }

        public override void Attack()
        {
            Console.WriteLine("The Skeleton attacks!");
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
        //public override int Health => 100;
        public override int AttackBaseDamage => 35;
        public override bool Hasloot => false;

        public FallenKnight()
        {
            this.Health = 100;
        }

        public override void Attack()
        {
            Console.WriteLine("The Fallen Knight attacks!");
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
        //public override int Health => 150;
        public override int AttackBaseDamage => 30;
        public override bool Hasloot => false;

        public Orc()
        {
            this.Health = 150;
        }

        public override void Attack()
        {
            Console.WriteLine("The Orc attacks!");
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

    public class PlayerRewritten : Creature
    {
        public override string Description => "An underprepared adventurer wishing to test their luck";
        public static List<string> inventory = new List<string>();

        public PlayerRewritten(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }

        public static void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        public static void InventoryContents()
        {
            foreach (string invitem in inventory)
            {
                Console.Write($"{invitem}, ");
            }
            Console.WriteLine();
        }
    }
}

