using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public static List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        //Adds item in the current room to inventory
        public static void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        //Displays items currently in the player inventory
        public static void InventoryContents()
        {
            foreach (string invitem in inventory)
            {
                Console.Write($"{invitem}, ");
            }
            Console.WriteLine();
        }
    }
}