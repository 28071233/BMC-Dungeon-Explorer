using System;
using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string title;
        private string description;
        private bool hasLoot;

        public Room(int roomSeed)
        {
            //Uses a randomly generated number to select which room to load
            if (roomSeed >= 90)
            {
                //Copies contents from RoomIndex table and loads it into the Current room
                this.title = roomIndex[2, 0];
                this.description = roomIndex[2, 1];
                this.hasLoot = bool.Parse(roomIndex[2, 2]);
            }
            else if (roomSeed >= 60)
            {
                this.title = roomIndex[1, 0];
                this.description = roomIndex[1, 1];
                this.hasLoot = bool.Parse(roomIndex[1, 2]);
            }
            else
            {
                this.title = roomIndex[0, 0];
                this.description = roomIndex[0, 1];
                this.hasLoot = bool.Parse(roomIndex[0, 2]);
            }
        }
        
        //Returns title to current room, used for checking if the room is an exit room
        public string GetTitle()
        {
            return title;
        }

        //Loads current room description
        public string GetDescription()
        {
            return description;
        }

        //Checks if the current room has loot, displays an message otherwise
        public bool GetLoot()
        {
            if (hasLoot == true)
            {
                //Uses a randomly generated number to select what loot is present in the current room
                Random randomNum = new Random();
                int lootSeed = randomNum.Next(0, 100);

                //Loot present in room is based on rarity
                if (lootSeed >= 50)
                {
                    Player.PickUpItem(lootTable[0]);
                }
                else if (lootSeed >= 20)
                {
                    Player.PickUpItem(lootTable[1]);
                }
                else if (lootSeed >= 1)
                {
                    Player.PickUpItem(lootTable[2]);
                }
                else
                {
                    Player.PickUpItem(lootTable[3]);
                }

                //Set "hasLoot" to false to prevent infinite collection of items
                Console.WriteLine("loot found!");
                hasLoot = false;
            }
            else
            {
                Console.WriteLine("no items of use could be found");
            }
            return hasLoot;
        }

        string[,] roomIndex =
            {
            //Contains contents of rooms in the format - Title : Description : has loot?
                {"Empty Room", "A cold, damp room void of colour", "false"},
                {"Treasure Room", "A cramped room composed of rotting wood and broken glass", "true" },
                {"Exit Room", "A lukewarm room with the sun seeping through the cracks", "false" }
            };

        string[] lootTable = { "Gold", "Health Flask", "Rope", "Choccy Milk" };
    }
}