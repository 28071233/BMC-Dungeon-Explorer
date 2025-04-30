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

        public bool SearchForItemInInventory()
        {
            bool itemFound = false;
            foreach ((string item, int amount) pair in Player.inventory)
            {
                if (pair.item.ToLower() == this.Name.ToLower())
                {
                    itemFound = true;
                    break;
                }

                Console.WriteLine("===========================");
                Console.WriteLine("Debug again steam happy");
                Console.WriteLine($"itemFound: {itemFound}");
                Console.WriteLine($"pair.item: {pair.item}");
                Console.WriteLine($"this.name: {this.Name}");
                Console.WriteLine($"this.name.Tolower(): {this.Name.ToLower()}");
            }

            return itemFound;
        }

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
            if (SearchForItemInInventory() == true)
            {
                Console.WriteLine($"{this.Name} used");
                Player.RemoveItem(this.Name);
            }
            else
            {
                Console.WriteLine($"You dont have any {this.Name} to use!");
            }
        }
    }

    public class HealthFlask : Item
    {
        public override string Name => "HealthFlask";
        public override string Description => "A potion that heals wounds";
        public override int Weight => 1;

        public override void UseItem()
        {
            if (SearchForItemInInventory() == true)
            {
                Console.WriteLine($"{this.Name} used");
                Player.RemoveItem(this.Name);
            }
            else
            {
                Console.WriteLine($"You dont have any {this.Name} to use!");
            }
        }
    }

    public class Rope : Item
    {
        public override string Name => "Rope";
        public override string Description => "A tool that guarentees your escape in dangerous situations";
        public override int Weight => 1;

        public override void UseItem()
        {
            if (SearchForItemInInventory() == true)
            {
                Console.WriteLine($"{this.Name} used");
                Player.RemoveItem(this.Name);
            }
            else
            {
                Console.WriteLine($"You dont have any {this.Name} to use!");
            }
        }
    }
}
