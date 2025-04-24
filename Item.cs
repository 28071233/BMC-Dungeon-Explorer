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
    }

    public class Gold : Item
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Weight => throw new NotImplementedException();

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }

    public class HealthFlask : Item
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Weight => throw new NotImplementedException();

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }

    public class Rope : Item
    {
        public override string Name => throw new NotImplementedException();
        public override string Description => throw new NotImplementedException();
        public override int Weight => throw new NotImplementedException();

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
