using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask.Discounts
{
    public class MultiOffer : Discount
    {
        public override string Description { get => "Multi-buy offer"; }

        public override decimal CalculateDiscount(ShoppingBasket basket)
        {
            decimal discount = 0;

            Item bread;
            Item beans;

            if (basket.GetItem("Bread", out bread))
            {
                if (basket.GetItem("Beans", out beans))
                {
                    if (bread.Quantity >= 1)
                    {
                        if (beans.Quantity >= 2)
                        {
                            discount = Offer(bread, beans);
                        }
                    }
                }
            }
            
            return discount;
        }

        private decimal Offer(Item bread, Item beans)
        {
            decimal discount = 0;

            int quantityToOffer = (int)Math.Floor((beans.Quantity * 0.5));
            int quantityOfBread = bread.Quantity;

            //We have less bread than 'offers' => all the bread can get the discount
            if (quantityOfBread <= quantityToOffer)
            {
                discount = ((bread.Price * bread.Quantity) * 0.5m);
            }
            //We have more bread than the 'offers' available => only allow discount for that amount of bread
            else if (quantityOfBread > quantityToOffer)
            {
                discount = ((bread.Price * quantityToOffer) * 0.5m);
            }

            return discount;
        }
    }
}
