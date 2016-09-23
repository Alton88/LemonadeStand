using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store{
        double[] lemonPrices;
        double[] sugarPrices;
        double[] icePrices;
        double[] cupPrices;
        public Store() {
            lemonPrices = new double[3] {0.61, 2.45, 4.45};
            sugarPrices = new double[3] { 0.61, 1.56, 3.41 };
            icePrices = new double[3] { 0.81, 2.04, 3.61 };
            cupPrices = new double[3] { 0.76, 1.59, 3.23 };
        }
        public bool LemonBuyingOptions(Inventory inventory, Player player) {
            int selection = 0;
            Console.Clear();
            Console.WriteLine("You have {0} Lemons and ${1:0.00} ", inventory.Lemons.Count, player.CashBox.Money);
            Console.WriteLine("Enter '1' to buy 10 Lemons for ${0:0.00}", lemonPrices[0]);
            Console.WriteLine("Enter '2' to buy 30 Lemons for ${0:0.00}", lemonPrices[1]);
            Console.WriteLine("Enter '3' to buy 75 Lemons for ${0:0.00}", lemonPrices[2]);
            Console.WriteLine("Enter '4' to Go Back to Inventory Menu.");

            while (selection < 1 || selection > 4) {
                try {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            if (selection == 1 && player.CashBox.Money >= lemonPrices[0])
            {
                return LemonCheckout(10, lemonPrices[0], inventory, player);
            }
            else if (selection == 2 && player.CashBox.Money >= lemonPrices[1])
            {
                return LemonCheckout(30, lemonPrices[1], inventory, player);
            }
            else if (selection == 3 && player.CashBox.Money >= lemonPrices[2])
            {
                return LemonCheckout(75, lemonPrices[2], inventory, player);
            }
            else if (selection == 4) { return true; }
            else { return false; }
            
        }
        public bool LemonCheckout(int amount, double price, Inventory inventory, Player player) {
            player.CashBox.Money -= price;
            player.CashBox.Expenses += price;
            for (int i = 0; i < amount; ++i) {
                inventory.Lemons.Add(new Lemon()); 
            }
            Console.Clear();
            return true;
        }
        public bool SugarBuyingOptions(Inventory inventory, Player player){
            int selection = 0;
            Console.Clear();
            Console.WriteLine("You have {0} Cups of Sugar and ${1:0.00} ", inventory.Sugar.Count, player.CashBox.Money);
            Console.WriteLine("Enter '1' to buy 8 Cups of Sugar for ${0:0.00}", sugarPrices[0]);
            Console.WriteLine("Enter '2' to buy 20 Cups of Sugar for ${0:0.00}", sugarPrices[1]);
            Console.WriteLine("Enter '3' to buy 48 Cups of Sugar for ${0:0.00}", sugarPrices[2]);
            Console.WriteLine("Enter '4' to Go Back to Inventory Menu.");

            while (selection < 1 || selection > 4)
            {
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (selection == 1 && player.CashBox.Money >= sugarPrices[0]){
                return SugarCheckout(8, sugarPrices[0], inventory, player);
            }
            else if (selection == 2 && player.CashBox.Money >= sugarPrices[1]){
                return SugarCheckout(20, sugarPrices[1], inventory, player);
            }
            else if (selection == 3 && player.CashBox.Money >= sugarPrices[2]){
                return SugarCheckout(48, sugarPrices[2], inventory, player);
            }
            else if (selection == 4) { return true; }
            else { return false; }
        }
        public bool SugarCheckout(int amount, double price, Inventory inventory, Player player){
            player.CashBox.Money -= price;
            player.CashBox.Expenses += price;
            for (int i = 0; i < amount; ++i){
                inventory.Sugar.Add(new Sugar());
            }
            Console.Clear();
            return true;
        }
        public bool IceBuyingOptions(Inventory inventory, Player player){
            int selection = 0;
            Console.Clear();
            Console.WriteLine("You have {0} Ice Cubes and ${1:0.00} ", inventory.Ice.Count, player.CashBox.Money);
            Console.WriteLine("Enter '1' to buy 100 Ice Cubes for ${0:0.00}", icePrices[0]);
            Console.WriteLine("Enter '2' to buy 250 Ice Cubes for ${0:0.00}", icePrices[1]);
            Console.WriteLine("Enter '3' to buy 500 Ice Cubes for ${0:0.00}", icePrices[2]);
            Console.WriteLine("Enter '4' to Go Back to Inventory Menu.");

            while (selection < 1 || selection > 4)
            {
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (selection == 1 && player.CashBox.Money >= icePrices[0]){
                return IceCheckout(100, icePrices[0], inventory, player);
            }
            else if (selection == 2 && player.CashBox.Money >= icePrices[1]){
                return IceCheckout(250, icePrices[1], inventory, player);
            }
            else if (selection == 3 && player.CashBox.Money >= icePrices[2]){
                return IceCheckout(500, icePrices[2], inventory, player);
            }
            else if (selection == 4) { return true; }
            else { return false; }
        }
        public bool IceCheckout(int amount, double price, Inventory inventory, Player player){
            player.CashBox.Money -= price;
            player.CashBox.Expenses += price;
            for (int i = 0; i < amount; ++i){
                inventory.Ice.Add(new Ice());
            }
            Console.Clear();
            return true;
        }
        public bool CupBuyingOptions(Inventory inventory, Player player){
            int selection = 0;
            Console.Clear();
            Console.WriteLine("You have {0} Paper Cups and ${1:0.00} ", inventory.Sugar.Count, player.CashBox.Money);
            Console.WriteLine("Enter '1' to buy 25 Paper Cups for ${0:0.00}", cupPrices[0]);
            Console.WriteLine("Enter '2' to buy 50 Paper Cups for ${0:0.00}", cupPrices[1]);
            Console.WriteLine("Enter '3' to buy 100 Paper Cups for ${0:0.00}", cupPrices[2]);
            Console.WriteLine("Enter '4' to Go Back to Inventory Menu.");

            while (selection < 1 || selection > 4)
            {
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (selection == 1 && player.CashBox.Money >= cupPrices[0]){
                return CupCheckout(25, cupPrices[0], inventory, player);
            }
            else if (selection == 2 && player.CashBox.Money >= cupPrices[1]){
                return CupCheckout(50, cupPrices[1], inventory, player);
            }
            else if (selection == 3 && player.CashBox.Money >= cupPrices[2]){
                return CupCheckout(100, cupPrices[2], inventory, player);
            }
            else if (selection == 4) { return true; }
            else { return false; }
        }
        public bool CupCheckout(int amount, double price, Inventory inventory, Player player){
            player.CashBox.Money -= price;
            player.CashBox.Expenses += price;
            for (int i = 0; i < amount; ++i){
                inventory.Cups.Add(new Cup());
            }
            Console.Clear();
            return true;
        }
    }
}
