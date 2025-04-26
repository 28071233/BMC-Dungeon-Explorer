using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class RoomRewritten
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract int LootChance { get; }
        public abstract int MaxLoot { get; }
        public virtual int CurrentLootNum { get; set; }
        public abstract int MonsterChance { get; }
        public abstract int MaxMonster { get; }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }
    }

    public class EmptyRoom : RoomRewritten
    {
        public override string Title => "Empty Room";
        public override string Description => "A cold, damp room void of colour";
        public override int LootChance => 15;
        public override int MaxLoot => 1;
        public override int MonsterChance => 25;
        public override int MaxMonster => 1;

        public EmptyRoom()
        {
            // variables needed
            // number of current monsters
            // number of current loot

            this.CurrentLootNum = 241;
        }
    }

    public class TreasureRoom : RoomRewritten
    {
        public override string Title => "Treasure Room";
        public override string Description => "A cramped room composed of rotting wood and broken glass";
        public override int LootChance => 100;
        public override int MaxLoot => 3;
        public override int MonsterChance => 65;
        public override int MaxMonster => 2;
    }

    public class MonsterRoom : RoomRewritten
    {
        public override string Title => "Monster Room";
        public override string Description => "A dimmly lit room with an ominous figure guarding the door...";
        public override int LootChance => 35;
        public override int MaxLoot => 2;
        public override int MonsterChance => 100;
        public override int MaxMonster => 3;
    }

    public class ExitRoom : RoomRewritten
    {
        public override string Title => "Exit Room";
        public override string Description => "A lukewarm room with the sun seeping through the cracks";
        public override int LootChance => 5;
        public override int MaxLoot => 1;
        public override int MonsterChance => 15;
        public override int MaxMonster => 1;
    }
}
