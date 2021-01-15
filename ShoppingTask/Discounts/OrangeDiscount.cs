using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Discounts
{
    public class OrangeDiscount : Discount
    {
        public override string Description { get => "Oranges 20% off"; }

        public override decimal CalculateDiscount(ShoppingBasket basket)
        {
            decimal discount = 0;

            Item item;

            if (basket.GetItem("Oranges", out item))
            {
                if (item.Quantity >= 1)
                {
                    discount = (item.Quantity * item.Price) * 0.2m;
                }
            }
            
            return discount;
        }
    }
}
