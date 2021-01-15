using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask
{
    public abstract class Discount
    {
        public abstract string Description { get; }

        public abstract decimal CalculateDiscount(ShoppingBasket basket);
    }
}
