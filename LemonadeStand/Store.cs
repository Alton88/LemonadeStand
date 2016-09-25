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
        int[] deals;
        public Store() {
            lemonPrices = new double[3] {0.61, 2.45, 4.45};
            sugarPrices = new double[3] { 0.61, 1.56, 3.41 };
            icePrices = new double[3] { 0.81, 2.04, 3.61 };
            cupPrices = new double[3] { 0.76, 1.59, 3.23 };
            deals = new int[] {10, 30, 70, 8, 20, 48, 100, 250, 500, 25, 50, 100};
        }
        public bool LemonBuyingOptions(Inventory inventory, Player player) {
            int choice = 0;
            
            while (choice < 1 || choice > 4) {
                Console.Clear();
                Console.WriteLine("You have {0} Lemons and ${1:0.00} ", inventory.Lemons.Count, player.CashBox.Money);
                Console.WriteLine("Enter \"1\" to buy {0} Lemons for ${1:0.00}", deals[0], lemonPrices[0]);
                Console.WriteLine("Enter \"2\" to buy {0} Lemons for ${1:0.00}", deals[1], lemonPrices[1]);
                Console.WriteLine("Enter \"3\" to buy {0} Lemons for ${1:0.00}", deals[2], lemonPrices[2]);
                Console.WriteLine("Enter \"4\" to Go Back to Inventory Menu.");
                Console.Write("\nEnter Your Option : ");
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            if (choice == 1 && player.CashBox.Money >= lemonPrices[0])
            {
                return LemonCheckout(deals[0], lemonPrices[0], inventory, player);
            }
            else if (choice == 2 && player.CashBox.Money >= lemonPrices[1])
            {
                return LemonCheckout(deals[1], lemonPrices[1], inventory, player);
            }
            else if (choice == 3 && player.CashBox.Money >= lemonPrices[2])
            {
                return LemonCheckout(deals[2], lemonPrices[2], inventory, player);
            }
            else if (choice == 4) { return true; }
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
            int choice = 0;
            
            while (choice < 1 || choice > 4)
            {
                Console.Clear();
                Console.WriteLine("You have {0} Cups of Sugar and ${1:0.00} ", inventory.Sugar.Count, player.CashBox.Money);
                Console.WriteLine("Enter \"1\" to buy {0} Cups of Sugar for ${1:0.00}", deals[3], sugarPrices[0]);
                Console.WriteLine("Enter \"2\" to buy {0} Cups of Sugar for ${1:0.00}", deals[4], sugarPrices[1]);
                Console.WriteLine("Enter \"3\" to buy {0} Cups of Sugar for ${1:0.00}", deals[5], sugarPrices[2]);
                Console.WriteLine("Enter \"4\" to Go Back to Inventory Menu.");
                Console.Write("\nEnter Your Option : ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (choice == 1 && player.CashBox.Money >= sugarPrices[0]){
                return SugarCheckout(deals[3], sugarPrices[0], inventory, player);
            }
            else if (choice == 2 && player.CashBox.Money >= sugarPrices[1]){
                return SugarCheckout(deals[4], sugarPrices[1], inventory, player);
            }
            else if (choice == 3 && player.CashBox.Money >= sugarPrices[2]){
                return SugarCheckout(deals[5], sugarPrices[2], inventory, player);
            }
            else if (choice == 4) { return true; }
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
            int choice = 0;
            
            while (choice < 1 || choice > 4)
            {
                Console.Clear();
                Console.WriteLine("You have {0} Ice Cubes and ${1:0.00} ", inventory.Ice.Count, player.CashBox.Money);
                Console.WriteLine("Enter \"1\" to buy {0} Ice Cubes for ${1:0.00}", deals[6], icePrices[0]);
                Console.WriteLine("Enter \"2\" to buy {0} Ice Cubes for ${1:0.00}", deals[7], icePrices[1]);
                Console.WriteLine("Enter \"3\" to buy {0} Ice Cubes for ${1:0.00}", deals[8], icePrices[2]);
                Console.WriteLine("Enter \"4\" to Go Back to Inventory Menu.");
                Console.Write("\nEnter Your Option : ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (choice == 1 && player.CashBox.Money >= icePrices[0]){
                return IceCheckout(deals[6], icePrices[0], inventory, player);
            }
            else if (choice == 2 && player.CashBox.Money >= icePrices[1]){
                return IceCheckout(deals[7], icePrices[1], inventory, player);
            }
            else if (choice == 3 && player.CashBox.Money >= icePrices[2]){
                return IceCheckout(deals[8], icePrices[2], inventory, player);
            }
            else if (choice == 4) { return true; }
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
            int choice = 0;
            
            while (choice < 1 || choice > 4)
            {
                Console.Clear();
                Console.WriteLine("You have {0} Paper Cups and ${1:0.00} ", inventory.Cups.Count, player.CashBox.Money);
                Console.WriteLine("Enter \"1\" to buy {0} Paper Cups for ${1:0.00}", deals[9], cupPrices[0]);
                Console.WriteLine("Enter \"2\" to buy {0} Paper Cups for ${1:0.00}", deals[10], cupPrices[1]);
                Console.WriteLine("Enter \"3\" to buy {0} Paper Cups for ${1:0.00}", deals[11], cupPrices[2]);
                Console.WriteLine("Enter \"4\" to Go Back to Inventory Menu.");
                Console.Write("\nEnter Your Option : ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            if (choice == 1 && player.CashBox.Money >= cupPrices[0]){
                return CupCheckout(deals[9], cupPrices[0], inventory, player);
            }
            else if (choice == 2 && player.CashBox.Money >= cupPrices[1]){
                return CupCheckout(deals[10], cupPrices[1], inventory, player);
            }
            else if (choice == 3 && player.CashBox.Money >= cupPrices[2]){
                return CupCheckout(deals[11], cupPrices[2], inventory, player);
            }
            else if (choice == 4) { return true; }
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
