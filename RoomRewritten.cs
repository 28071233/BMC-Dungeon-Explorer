using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class RoomRewritten
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract bool HasLoot { get; }

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
        public override bool HasLoot => false;

    }

    public class TreasureRoom : RoomRewritten
    {
        public override string Title => "Treasure Room";
        public override string Description => "A cramped room composed of rotting wood and broken glass";
        public override bool HasLoot => true;
    }

    public class ExitRoom : RoomRewritten
    {
        public override string Title => "Exit Room";
        public override string Description => "A lukewarm room with the sun seeping through the cracks";
        public override bool HasLoot => false;
    }
}
