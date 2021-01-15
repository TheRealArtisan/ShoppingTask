using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Items
{
    public class Milk : Item
    {
        public override string Name { get => "Milk"; }

        public override List<string> SearchNames { get => new List<string>() { "milk" }; }

        public override decimal Price { get => 1.50m; }
    }
}
