using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        List <Player> players;
        UserInterface userInterface;
        bool isComputerPlayer;
        Day day;
        int numberOfdays;
        FileWriter fileWriter;
        
        Pitcher pitcher;
        public Game() {
            players = new List<Player>();
            userInterface = new UserInterface();
            pitcher = new Pitcher("", 0);
            numberOfdays = 1;
            fileWriter = new FileWriter();
        }
        public void startGame() {
            int numberOfPlayers = userInterface.Menu();
            Console.Write("Player 1 Please Enter Your Name ");
            players.Add(new Human(Console.ReadLine()));
            Console.Clear();
            if (numberOfPlayers > 1) {
                if (numberOfPlayers == 2)
                {
                    Console.Write("Player 2 Please Enter Your Name ");
                    players.Add(new Human(Console.ReadLine()));
                    Console.Clear();
                }
                else {
                    players.Add(new Computer("Computer"));
                    isComputerPlayer = true;
                    numberOfPlayers = 2;
                }
            }
                for (int i = 0; i < numberOfdays; ++i) {
                    day = new Day();
                    Console.WriteLine("Day {0}", i + 1);
                    day.Count = i + 1;
                    GamePlay(day, numberOfPlayers);
                }
            for (int i = 0; i < numberOfPlayers; ++i) {
                userInterface.DisplayResults(players[i]);
                Console.WriteLine("Stats will be saved to file, GOOD BYE!!!");
                fileWriter.WriteToFile(players[0]);
            }
        }
        public void GamePlay(Day day, int numberOfPlayers) {
            int index = 0;
            if (numberOfPlayers == 1 || isComputerPlayer) {
                while (index < 1)
                {
                    userInterface.AskPlayerToBuyItems(players[index].LemonadeStand.Inventory, players[index], day);
                    userInterface.PriceAndRecipe(day, players[index].LemonadeStand.Inventory, players[index]);
                    ++index;
                }
            }
            else if (numberOfPlayers == 2) {
                    while (index < numberOfPlayers)
                    {
                        userInterface.AskPlayerToBuyItems(players[index].LemonadeStand.Inventory, players[index], day);
                        userInterface.PriceAndRecipe(day, players[index].LemonadeStand.Inventory, players[index]);
                        ++index;
                    }
                }   
            if (isComputerPlayer) {
                GetInventoryForComputer(players[1], day);
                GetRecipeForComputer(day, players[1]);
            }
            for (int i = 0; i < numberOfPlayers; ++i) {
                for (int j = 0; j < day.Customers.Count; ++j) {
                    if (!pitcher.IsEmpty()) {
                        if (day.Customers[j].BuyLemonade(pitcher.Type, players[i].LemonadeStand)) {
                            --pitcher.CupsInPitcher;
                            players[i].CashBox.Money += players[i].LemonadeStand.PricePerCup;
                            players[i].CashBox.Income += players[i].LemonadeStand.PricePerCup;
                            players[i].LemonadeStand.AmountSold += 1;
                            players[i].LemonadeStand.RemoveCupsFromInventory(1, players[i].LemonadeStand.Inventory);
                        }
                    }
                    else {
                        if (players[i].CheckForPitcherIngredientsInInventory(players[i].LemonadeStand.Inventory)) {
                            pitcher = players[i].LemonadeStand.MakePitcher(players[i].LemonadeStand.Inventory, players[i]); }
                        else players[i].LemonadeStand.IsSoldOut = true;
                    }
                }
            }
            Console.Clear();
            for (int i = 0; i < numberOfPlayers; ++i) {
                Console.WriteLine("\nToday's Forcast is {0} \nTemperature is {1}", day.Weather.ForcastForToday, day.Weather.Temperature);
                if (players[i].LemonadeStand.IsSoldOut) { Console.WriteLine("\n{0}, Has Sold Out of Lemonade.", players[i].Name); }
                Console.WriteLine("\n{0} Managed to Sell {1} Cups of Lemonade to {2} Potential Customers.",players[i].Name, players[i].LemonadeStand.AmountSold, day.Customers.Count);

                players[i].LemonadeStand.AmountSold = 0;
            }
            Console.Write("\nPress Enter to Continue:");
            Console.ReadKey(); 
            Console.Clear();
        }
        public void GetInventoryForComputer(Player player, Day day) {
            Store store = new Store();
            if (player.LemonadeStand.Inventory.Cups.Count < 100) { store.CupCheckout(100, 3.23, player.LemonadeStand.Inventory, player); }
            if (player.LemonadeStand.Inventory.Lemons.Count < 55) { store.LemonCheckout(75, 4.45, player.LemonadeStand.Inventory, player); }
            if (player.LemonadeStand.Inventory.Sugar.Count < 55) { store.SugarCheckout(100, 3.41, player.LemonadeStand.Inventory, player); }
            if (player.LemonadeStand.Inventory.Ice.Count < 500) { store.IceCheckout(500, 3.61, player.LemonadeStand.Inventory, player); }
        }
        public void GetRecipeForComputer(Day day, Player player) {
            if (day.Weather.Temperature > 80) { player.LemonadeStand.PricePerCup = 0.80; }
            else if (day.Weather.Temperature > 70) { player.LemonadeStand.PricePerCup = 0.70; }
            else if (day.Weather.Temperature > 60) { player.LemonadeStand.PricePerCup = 0.60; }
            else player.LemonadeStand.PricePerCup = 0.35;

            player.LemonadeStand.LemonsPerPitcher = 5;
            player.LemonadeStand.SugarPerPitcher = 5;
            player.LemonadeStand.IcePerCup = 5;
        }
    }
}
