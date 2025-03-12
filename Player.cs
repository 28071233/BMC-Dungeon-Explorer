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
        public static void PickUpItem(string item)
        {
            inventory.Add(item);
        }
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