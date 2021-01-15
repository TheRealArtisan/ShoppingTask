using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask
{
    public abstract class Item
    {
        public string Key { get => this.GetType().Name; }

        public abstract string Name { get; }

        public abstract List<string> SearchNames { get; }

        public abstract decimal Price { get; }

        public int Quantity { get; set; } = 0;
    }
}
