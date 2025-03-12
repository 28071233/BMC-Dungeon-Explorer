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
            // Uses a randomly generated number to select which room to loadd
            if (roomSeed >= 90)
            {
                // copies contents from RoomIndex table and loads it into the Current room
                this.title = RoomIndex[2, 0];
                this.description = RoomIndex[2, 1];
                this.hasLoot = bool.Parse(RoomIndex[2, 2]);
            }
            else if (roomSeed >= 60)
            {
                this.title = RoomIndex[1, 0];
                this.description = RoomIndex[1, 1];
                this.hasLoot = bool.Parse(RoomIndex[1, 2]);
            }
            else
            {
                this.title = RoomIndex[0, 0];
                this.description = RoomIndex[0, 1];
                this.hasLoot = bool.Parse(RoomIndex[0, 2]);
            }
        }
        
        //returns title to current room, used for checking if the room is an exit room
        public string GetTitle()
        {
            return title;
        }

        //loads current room description
        public string GetDescription()
        {
            return description;
        }

        //checks if the current room has loot, displays an message otherwise
        public bool GetLoot()
        {
            if (hasLoot == true)
            {
                // Uses a randomly generated number to select what loot is present in the current room
                Random randomNum = new Random();
                int lootseed = randomNum.Next(0, 100);

                if (lootseed >= 50)
                {
                    Player.PickUpItem(lootTable[0]);
                }
                else if (lootseed >= 20)
                {
                    Player.PickUpItem(lootTable[1]);
                }
                else if (lootseed >= 1)
                {
                    Player.PickUpItem(lootTable[2]);
                }
                else
                {
                    Player.PickUpItem(lootTable[3]);
                }


                Console.WriteLine("loot found!");
                hasLoot = false;
            }
            else
            {
                Console.WriteLine("no items of use could be found");
            }
            return hasLoot;
        }

        string[,] RoomIndex =
            {
            // Contains contents of rooms in the format - Title : Description : has loot?
                {"Empty Room", "A cold, damp room void of colour", "false"},
                {"Treasure Room", "A cramped room composed of rotting wood and broken glass", "true" },
                {"Exit Room", "A lukewarm room with the sun seeping through the cracks", "false" }
            };

        string[] lootTable = { "Gold", "Health Flask", "Rope", "Choccy Milk" };
    }
}