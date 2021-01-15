using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Items
{
    public class Beans : Item
    {
        public override string Name { get => "Beans"; }
        
        public override List<string> SearchNames { get => new List<string>() { "beans" }; }

        public override decimal Price { get => 0.98m; }
    }
}
