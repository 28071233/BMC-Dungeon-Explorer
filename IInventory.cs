using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    interface IInventory
    {
        void PickUpItem(string item);

        void RemoveItem(string item);

        void InventoryContents();
    }
}
