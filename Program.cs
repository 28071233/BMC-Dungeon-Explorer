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
            RoomRewritten room = new EmptyRoom();
            Console.WriteLine(room.CurrentLootNum);

            PlayerRewritten testPlayer = new PlayerRewritten("testPlayer", 100);
            Orc testOrc = new Orc();

            Console.WriteLine($"{testPlayer.Name} {testPlayer.Health}");
            Console.WriteLine($"{testOrc.Name} {testOrc.Health}");
            Console.WriteLine("+++++++++++++++");

            testPlayer.Health = 0;
            if (testPlayer.Health == 0)
            {
                Console.WriteLine($"{testPlayer.Name} {testPlayer.Health}");
                Console.WriteLine($"{testOrc.Name} {testOrc.Health}");
                Console.WriteLine("GG!!");
            }



            Game game = new Game();
            game.Start();
            Console.WriteLine("\nProgram terminated, press any key to close...");
            Console.ReadKey();
        }
    }
}
