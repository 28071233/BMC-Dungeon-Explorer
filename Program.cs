using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Room room = new ExitRoom();
            Console.WriteLine("+++++++++++++++");
            Console.WriteLine($"Number of Loot: {room.CurrentLootNum}");
            Console.WriteLine($"Number of Monsters: {room.CurrentMonsterNum}");


            Game game = new Game();
            game.Start();
            Console.WriteLine("\nProgram terminated, press any key to close...");
            Console.ReadKey();
        }
    }
}
