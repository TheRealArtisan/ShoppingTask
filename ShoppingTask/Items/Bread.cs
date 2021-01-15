using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Items
{
    public class Bread : Item
    {
        public override string Name { get => "Bread"; }

        public override List<string> SearchNames { get => new List<string>() { "bread" }; }

        public override decimal Price { get => 0.84m; }
    }
}
