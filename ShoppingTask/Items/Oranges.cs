using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Items
{
    public class Oranges : Item
    {
        public override string Name { get => "Oranges"; }

        public override List<string> SearchNames { get => new List<string>() { "oranges", "orange" }; }

        public override decimal Price { get => 1.90m; }
    }
}
