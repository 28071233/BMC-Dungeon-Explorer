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

        public void GetDescription()
        {
            Console.WriteLine(Description);
        }
    }

    public class Gold : Item
    {
        public override string Name => "Gold";
        public override string Description => "Tattered coins from a long time ago";
        public override int Weight => 0;

        public override void UseItem()
        {
            Console.WriteLine("gold used");
            Player.RemoveItem(this.Name);
        }
    }

    public class HealthFlask : Item
    {
        public override string Name => "Healthflask";
        public override string Description => "A potion that heals wounds";
        public override int Weight => 1;

        public override void UseItem()
        {
            Console.WriteLine("HealthFlask used");
            Player.RemoveItem(this.Name);
        }
    }

    public class Rope : Item
    {
        public override string Name => "Rope";
        public override string Description => "A tool that guarentees your escape in dangerous situations";
        public override int Weight => 1;

        public override void UseItem()
        {
            Player.RemoveItem(this.Name);
            Console.WriteLine("rope used");
        }
    }
}
