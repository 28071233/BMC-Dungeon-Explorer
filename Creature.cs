using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Creature
    {
        public string Name;
        public string Description;
        public int Health;

        public Creature(string name, string description, int health)
        {
            this.Name = name;
            this.Description = description;
            this.Health = health;
        }
    }

    public class Merchant : Creature
    {
        public Merchant(string name, string description, int health) 
            : base(name, description, health)
        {
            this.Name = name;
            this.Description = description;
            this.Health = health;
        }

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

    public class Monster : Creature
    {
        public int AttackBaseDamage;
        public bool Hasloot;

        public Monster(string Name, string Description, int Health, int attackBaseDamage, bool hasloot)
            : base(Name, Description, Health)
        {
            this.Name = Name;
            this.Description = Description;
            this.Health = Health;
            this.AttackBaseDamage = attackBaseDamage;
            this.Hasloot = hasloot;
        }

        public void Attack()
        {
            Console.WriteLine("The Monster attacked!");
        }

        public void SpecialAttack()
        {
            Console.WriteLine("The Monster used it special ability!");
        }

        public void Flee()
        {
            Console.WriteLine("The Monster Fleed!");
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }
    }

    public class Skeleton : Monster
    {
        public Skeleton(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }
    }

    public class FallenKnight : Monster
    {
        public FallenKnight(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }
    }

    public class Orc : Monster
    {
        public Orc(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }
    }

    public class PlayerRewritten : Creature
    {
        public PlayerRewritten(string name, string description, int health) 
            : base(name, description, health)
        {
            this.Name = name;
            this.Description = description;
            this.Health = health;
        }
    }
}

