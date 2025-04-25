using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract int Weight { get; }

        public abstract void UseItem();
    }

    public class Gold : Item
    {
        public override string Name => "Gold";
        public override string Description => "Tattered coins from a long time ago";
        public override int Weight => 0;

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }

    public class HealthFlask : Item
    {
        public override string Name => "Health flask";
        public override string Description => "A potion that heals wounds";
        public override int Weight => 1;

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }

    public class Rope : Item
    {
        public override string Name => "Rope";
        public override string Description => "A tool that guarentees your escape in dangerous situations";
        public override int Weight => 1;

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
