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

                /*
                Console.WriteLine("===========================");
                Console.WriteLine("Debug again steam happy");
                Console.WriteLine($"itemFound: {itemFound}");
                Console.WriteLine($"pair.item: {pair.item}");
                Console.WriteLine($"this.name: {this.Name}");
                Console.WriteLine($"this.name.Tolower(): {this.Name.ToLower()}");
                */
            }

            return itemFound;
        }

        public void GetDescription()
        {
            Console.WriteLine(Description);
        }
    }

    public abstract class Equippable : Item
    {
        public abstract string Type { get; }

        public override void UseItem()
        {
            if (SearchForItemInInventory() == true)
            {
                EquipItem();
            }
            else
            {
                Console.WriteLine($"You dont have a {this.Name} to equip!");
            }
        }
        public void EquipItem()
        {
            if (this.Type == "Weapon")
            {
                if (Player.EquippedWeapon == this.Name)
                {
                    Console.WriteLine("You're already wielding this weapon!");
                }
                else
                {
                    Player.PickUpItem(Player.EquippedWeapon);
                    Player.EquippedWeapon = this.Name;
                    Player.RemoveItem(this.Name);
                    Console.WriteLine($"{this.Name} Equipped");
                }
            }
            else
            {
                if (Player.EquippedArmour == this.Name)
                {
                    Console.WriteLine("You're already wearing this set of armour!");
                }
                else
                {
                    Player.PickUpItem(Player.EquippedArmour);
                    Player.EquippedArmour = this.Name;
                    Player.RemoveItem(this.Name);
                    Console.WriteLine($"{this.Name} Equipped");
                }
            }
        }

        
    }

    public abstract class Weapon : Equippable
    {
        public abstract int AttackBaseDamage { get; }
    }

    public class RustySword : Weapon
    {
        public override string Name => "RustySword";
        public override string Description => "A dull blade with a jagged edge";
        public override int Weight => 1;
        public override string Type => "Weapon";
        public override int AttackBaseDamage => 20;
    }

    public class WornSword : Weapon
    {
        public override string Name => "WornSword";
        public override string Description => "A sword with visable scratches and a discoloured handle";
        public override int Weight => 1;
        public override string Type => "Weapon";
        public override int AttackBaseDamage => 30;
    }

    public abstract class Armour : Equippable
    {
        public abstract int ArmourBaseDefense { get; }

    }

    public class RustyArmour : Armour
    {
        public override string Name => "RustyArmour";

        public override string Description => "A rough set of corroded metal that could to fall apart at any time";

        public override int Weight => 1;
        public override string Type => "Armour";
        public override int ArmourBaseDefense => 10;
    }

    public class WornArmour : Armour
    {
        public override string Name => "WornArmour";
        public override string Description => "A chipped set of armour with some loose plates";
        public override int Weight => 1;
        public override string Type => "Armour";
        public override int ArmourBaseDefense => 30;
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
