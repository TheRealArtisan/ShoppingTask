using ShoppingTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting Shopping Basket..." + Environment.NewLine + Environment.NewLine);

                ShoppingBasket basket = new ShoppingBasket();

                basket.GetCommand(Console.ReadLine());

                Console.WriteLine(basket.Output());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine(Environment.NewLine + "Finished.");
                Console.ReadKey();
            }
        }
    }
}
