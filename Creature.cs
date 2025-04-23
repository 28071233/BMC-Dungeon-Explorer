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
            Console.WriteLine("The Monter used it special ability!");
        }

        public void Flee()
        {
            Console.WriteLine("The Monster Fleed!");
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

