using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public abstract string Name { get;  }
        public abstract string Description { get; }
        public abstract int Health { get; }
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
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Health => throw new NotImplementedException();
        public override int AttackBaseDamage => throw new NotImplementedException();
        public override bool Hasloot => throw new NotImplementedException();


        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public override void Flee()
        {
            throw new NotImplementedException();
        }

        /*public Goblin(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }*/
    }

    public class Skeleton : Monster
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Health => throw new NotImplementedException();
        public override int AttackBaseDamage => throw new NotImplementedException();
        public override bool Hasloot => throw new NotImplementedException();


        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public override void Flee()
        {
            throw new NotImplementedException();
        }

        /*public Skeleton(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }*/
    }

    public class FallenKnight : Monster
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Health => throw new NotImplementedException();
        public override int AttackBaseDamage => throw new NotImplementedException();
        public override bool Hasloot => throw new NotImplementedException();


        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public override void Flee()
        {
            throw new NotImplementedException();
        }

        /*public FallenKnight(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }*/
    }

    public class Orc : Monster
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Health => throw new NotImplementedException();
        public override int AttackBaseDamage => throw new NotImplementedException();
        public override bool Hasloot => throw new NotImplementedException();


        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public override void Flee()
        {
            throw new NotImplementedException();
        }

        /*public Orc(string Name, string Description, int Health, int attackBaseDamage, bool hasloot) 
            : base(Name, Description, Health, attackBaseDamage, hasloot)
        {
        }*/
    }

    public class PlayerRewritten : Creature
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Health => throw new NotImplementedException();

        /*public PlayerRewritten(string name, string description, int health) 
            : base(name, description, health)
        {
            this.Name = name;
            this.Description = description;
            this.Health = health;
        }*/
    }
}

