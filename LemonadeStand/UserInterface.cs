using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        Store store;
        public UserInterface() { store = new Store(); }
        public int Menu() {          
            int numberOfPlayers = 0;

            while (numberOfPlayers < 1 || numberOfPlayers > 4)
            {
                Console.WriteLine("Welcome To My Lemonade Stand!");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("Please Enter \"1\" to Play the One Player Game");
                Console.WriteLine("Please Enter \"2\" to Play the Two Player Game");
                Console.WriteLine("Please Enter \"3\" to Play Against the Computer");
                Console.WriteLine("Please Enter \"4\" to Load Saved Game");
                Console.Write("\nEnter Your Option : ");
                try
                {
                    numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}\n\nYou did not enter a valid number. \nPlease try again!\n", e);
                }
                Console.Clear();
            }
            return numberOfPlayers;
        }
        public void AskPlayerToBuyItems(Inventory inventory, Player player, Day day) {
            Console.Clear();
            int choice = 0;
            while (choice != 5) {
                Console.WriteLine("Day {0}", player.DaysPlayed);
                Console.WriteLine("\nToday's Forcast is {0} \nTemperature is {1}", day.Weather.ForcastForToday, day.Weather.Temperature);
                Console.WriteLine("\nMoney: ${0: 0.00}\n", player.CashBox.Money);
                Console.WriteLine("Inventory/Purchasing");
                Console.WriteLine("--------------------");
                Console.WriteLine("{0} Paper Cups / Enter \"1\" to Purchase Cups ", inventory.Cups.Count);
                Console.WriteLine("{0} Lemons     / Enter \"2\" to Purchase Lemons", inventory.Lemons.Count);
                Console.WriteLine("{0} Sugar      / Enter \"3\" to Purchase Sugar", inventory.Sugar.Count);
                Console.WriteLine("{0} Ice Cubes  / Enter \"4\" to Purchase Ice Cubes", inventory.Ice.Count);
                Console.WriteLine("ENTER \"5\" TO EXIT MENU");
                Console.Write("\n{0}, Enter Your Option : ", player.Name);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                if (choice > 0 || choice < 5) { BuyInventory(inventory, player, day, choice); }
            }
            
        }
        public void BuyInventory(Inventory inventory, Player player, Day day, int choice) {

            if (choice == 1) {
                if (!store.CupBuyingOptions(inventory, player)) { Console.WriteLine("Insufficent Funds, Try Again!"); }
            }
            else if (choice == 2) {
                if (!store.LemonBuyingOptions(inventory, player)) { Console.WriteLine("Insufficent Funds, Try Again!"); }
            }
            else if (choice == 3) {
                if (!store.SugarBuyingOptions(inventory, player)) { Console.WriteLine("Insufficent Funds, Try Again!"); }
            }
            else if (choice == 4) {
                if (!store.IceBuyingOptions(inventory, player)) { Console.WriteLine("Insufficent Funds, Try Again!"); }
            }
            Console.Clear();
        }
        public void PriceAndRecipe(Day day, Inventory inventory, Player player) {
            Console.Clear();
            int choice = 0;
            
            while (choice < 1 || choice > 100)
            {
                Console.Clear();
                PriceMenu(day, player);
                Console.Write("{0}, Enter Price per Cup (1 - 100) : ", player.Name);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    player.LemonadeStand.PricePerCup = Convert.ToDouble((choice * 0.01));
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.Clear();
            }
            choice = 0;
            
            while (choice < 1 || choice > 10)
            {
                Console.Clear();
                PriceMenu(day, player);
                Console.Write("{0}, Enter Lemons per Pitcher (1 - 10) : ", player.Name);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    player.LemonadeStand.LemonsPerPitcher = choice;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.Clear();
            }
            choice = 0;
            
            while (choice < 1 || choice > 10){
                Console.Clear();
                PriceMenu(day, player);
                Console.Write("{0}, Enter Sugar per Pitcher (1 - 10) : ", player.Name);
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                    player.LemonadeStand.SugarPerPitcher = choice;
                }
            catch (Exception e) { Console.WriteLine(e.Message); }
                Console.Clear();
            }
            choice = 0;
            PriceMenu(day, player);
            Console.Write("{0}, Enter Ice per Cup (1 - 10) : ", player.Name);
            while (choice < 1 || choice > 10)
            {
                Console.Clear();
                PriceMenu(day, player);
                Console.Write("{0}, Enter Ice per Cup (1 - 10) : ", player.Name);
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                    player.LemonadeStand.IcePerCup = choice;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.Clear();
            }
            Console.Write("\n{0}, Would You Like to Buy More Ingredients Before You Start Your Day? \"y/n\" : ", player.Name);
            if (Console.ReadLine().ToLower() == "y") {
                Console.Clear();
                AskPlayerToBuyItems(inventory, player, day); }
        }
        public void DisplayResults(Player player) {           
            Console.WriteLine("\n{0}'s End of Season Report:\n", player.Name);
            Console.WriteLine("Total Income:   ${0:0.00}", player.CashBox.Income);
            Console.WriteLine("Total Expenses: ${0:0.00}", player.CashBox.Expenses);
            Console.WriteLine("Total Money:    ${0:0.00}", player.CashBox.Money);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Net Profit/Loss: ${0:0.00}", player.CashBox.NetProfit);
        }
        public void PriceMenu(Day day ,Player player) {
            Console.WriteLine("Day {0}", player.DaysPlayed);
            Console.WriteLine("\nToday's Forcast is {0} \nTemperature is {1}\n", day.Weather.ForcastForToday, day.Weather.Temperature);
            Console.WriteLine("Price and Quality Control");
            Console.WriteLine("-------------------------");
        }
    }
}
