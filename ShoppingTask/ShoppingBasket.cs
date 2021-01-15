using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask
{
    public class ShoppingBasket
    {
        public decimal Subtotal { get => CalculateSubtotal(); }

        public DiscountModel Discount { get; }

        public decimal Total { get => CalculateTotal(); }

        private Dictionary<string, Item> Items { get; }

        public ShoppingBasket()
        {
            Items = new Dictionary<string, Item>();
            Discount = new DiscountModel(this);
        }

        public void AddItem(Item item)
        {
            Item value;
            if (Items.TryGetValue(item.Key, out value))
            {
                value.Quantity++;
                Items[item.Key] = value;
            }
            else
            {
                item.Quantity = 1;
                Items.Add(item.Key, item);
            }
        }

        public bool GetItem(string key, out Item item)
        {
            return Items.TryGetValue(key, out item);
        }

        public void GetCommand(string command)
        {
            string[] words = command.Split(' ');

            switch (words[0].ToLower())
            {
                case "pricebasket":
                    InputCommand(words);
                    break;
                default:
                    break;
            }
        }

        private void InputCommand(string[] command)
        {
            List<Item> items = typeof(Item).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Item)) && !t.IsAbstract).Select(t => (Item)Activator.CreateInstance(t)).ToList();

            //For each word (excluding 'pricebasket') add it to the basket
            for (int i = 1; i < command.Length; i++)
            {
                string word = command[i].ToLower();

                //Find which item it is
                foreach (var item in items)
                {
                    if (item.SearchNames.Contains(word))
                    {
                        AddItem((Item)Activator.CreateInstance(item.GetType()));
                    }
                }
            }
        }

        public string Output()
        {
            string subtotal = SubTotalString();

            string discounts = Discount.DiscountString();

            string total = TotalString();

            return subtotal + Environment.NewLine + discounts + Environment.NewLine + total;
        }

        private string SubTotalString()
        {
            return $"Subtotal: {Subtotal.ToGBP()}";
        }

        private decimal CalculateSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in Items.Values)
            {
                subtotal += (item.Price * item.Quantity);
            }
            return subtotal;
        }

        private string TotalString()
        {
            return $"Total: {Total.ToGBP()}";
        }

        private decimal CalculateTotal()
        {
            return Subtotal - Discount.TotalDiscount;
        }
    }

    public class DiscountModel
    {
        private ShoppingBasket ShoppingBasket { get; }

        private List<Discount> Discounts { get; }

        public decimal TotalDiscount { get => CalculateTotalDiscount(); }

        public DiscountModel(ShoppingBasket basket)
        {
            this.ShoppingBasket = basket;

            Discounts = typeof(Discount).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Discount)) && !t.IsAbstract).Select(t => (Discount)Activator.CreateInstance(t)).ToList();
        }

        private decimal CalculateTotalDiscount()
        {
            decimal total = 0;

            foreach (var discount in Discounts)
            {
                total += discount.CalculateDiscount(ShoppingBasket);
            }

            return total;
        }

        public string DiscountString()
        {
            if (TotalDiscount > 0)
            {
                List<string> discountStrings = new List<string>();

                foreach (var discount in Discounts)
                {
                    decimal d = discount.CalculateDiscount(ShoppingBasket);
                    if (d > 0)
                    {
                        discountStrings.Add($"{discount.Description}: -{d.ToGBP()}");
                    }
                }

                return string.Join(Environment.NewLine, discountStrings);
            }
            else
            {
                return "(no offers available)";
            }
        }
    }

    public static class Extentions
    {
        public static string ToGBP(this decimal value)
        {
            value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            if (value < 1.00m)
            {
                value = value * 100;

                return $"{value.ToString("F0")}p";
            }
            else
            {
                return $"£{value.ToString("F")}";
            }
        }
    }
}