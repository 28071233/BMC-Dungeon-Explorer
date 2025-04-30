using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Room
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract int LootChance { get; }
        public abstract int MaxLoot { get; }
        public virtual int CurrentLootNum { get; set; }
        public abstract int MonsterChance { get; }
        public abstract int MaxMonster { get; }
        public virtual int CurrentMonsterNum { get; set; }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void GenerateLootNum()
        {
            int nextLootChance = this.LootChance;
            this.CurrentLootNum = 0;

            while (this.CurrentLootNum < this.MaxLoot)
            {
                int randomNum = Game.RNG();
                if (randomNum < nextLootChance)
                {
                    this.CurrentLootNum += 1;
                    nextLootChance = nextLootChance / 2;
                }
                else
                {
                    break;
                }
            }
        }

        public void GetLoot()
        {
            if (this.CurrentLootNum > 0)
            {
                int randomInt = Game.RNG();
                if (randomInt >= 50)
                {
                    Console.WriteLine("You found some Gold!");
                    Player.PickUpItem("Gold");
                }
                else if (randomInt >= 20)
                {
                    Console.WriteLine("You found a Health Flask!");
                    Player.PickUpItem("HealthFlask");
                }
                else if (randomInt >= 1)
                {
                    Console.WriteLine("You found some Rope!");
                    Player.PickUpItem("Rope");
                }
                else
                {
                    Console.WriteLine("You found Choccy Milk!!!!!");
                    Player.PickUpItem("Choccy Milk");
                }
                this.CurrentLootNum -= 1;
            }
            else
            {
                Console.WriteLine("No items of use could be found here...");
            }
        }

        public void GenerateMonsterNum()
        {
            int nextMonsterChance = this.MonsterChance;
            this.CurrentMonsterNum = 0;

            while (this.CurrentMonsterNum < this.MaxMonster)
            {
                int randomNum = Game.RNG();
                if (randomNum < nextMonsterChance)
                {
                    this.CurrentMonsterNum += 1;
                    nextMonsterChance = nextMonsterChance / 2;
                }
                else
                {
                    break;
                }
            }
        }
    }

    public class EmptyRoom : Room
    {
        public override string Title => "Empty Room";
        public override string Description => "A cold, damp room void of colour";
        public override int LootChance => 15;
        public override int MaxLoot => 1;
        public override int MonsterChance => 25;
        public override int MaxMonster => 1;

        public EmptyRoom()
        {
            GenerateMonsterNum();
            GenerateLootNum();
        }
    }

    public class TreasureRoom : Room
    {
        public override string Title => "Treasure Room";
        public override string Description => "A cramped room composed of rotting wood and broken glass";
        public override int LootChance => 100;
        public override int MaxLoot => 3;
        public override int MonsterChance => 65;
        public override int MaxMonster => 2;

        public TreasureRoom()
        {
            GenerateMonsterNum();
            GenerateLootNum();
        }
    }

    public class MonsterRoom : Room
    {
        public override string Title => "Monster Room";
        public override string Description => "A dimmly lit room with an ominous figure guarding the door...";
        public override int LootChance => 35;
        public override int MaxLoot => 2;
        public override int MonsterChance => 100;
        public override int MaxMonster => 3;

        public MonsterRoom()
        {
            GenerateMonsterNum();
            GenerateLootNum();
        }
    }

    public class ExitRoom : Room
    {
        public override string Title => "Exit Room";
        public override string Description => "A lukewarm room with the sun seeping through the cracks";
        public override int LootChance => 5;
        public override int MaxLoot => 1;
        public override int MonsterChance => 15;
        public override int MaxMonster => 1;

        public ExitRoom()
        {
            GenerateMonsterNum();
            GenerateLootNum();
        }
    }
}
