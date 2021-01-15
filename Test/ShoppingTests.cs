using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingTask;
using ShoppingTask.Items;

namespace Test
{
    [TestClass]
    public class ShoppingTests
    {
        [TestMethod]
        public void BasketSubtotalTest()
        {
            ShoppingBasket basket = new ShoppingBasket();

            basket.AddItem(new Oranges());
            
            Assert.AreEqual(1.90m, basket.Subtotal);
        }

        [TestMethod]
        public void BasketTotalTest()
        {
            ShoppingBasket basket = new ShoppingBasket();

            basket.AddItem(new Oranges());

            Assert.AreEqual((1.90m - (1.90m * 0.2m)), basket.Total);
        }

        [TestMethod]
        public void BasketDiscountTest()
        {
            ShoppingBasket basket = new ShoppingBasket();

            basket.AddItem(new Oranges());

            Assert.AreEqual((1.90m * 0.2m), basket.Discount.TotalDiscount); 
        }
    }
}
