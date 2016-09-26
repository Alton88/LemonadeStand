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
        FileReader fileReader;        
        Pitcher pitcher;
        public Game() {
            players = new List<Player>();
            userInterface = new UserInterface();
            pitcher = new Pitcher("", 0);
            numberOfdays = 7;
            fileWriter = new FileWriter();
            fileReader = new FileReader();
            isComputerPlayer = false;
        }
        public void StartGame() {
            int numberOfPlayers = userInterface.Menu();
            numberOfPlayers = numberOfPlayers < 4 ? UserLoginPrompt(numberOfPlayers): LoadSavedGame();
            RunThroughDays(numberOfPlayers);
            DisplayStats(numberOfPlayers);
            SavePlayer1StatsToFile(numberOfPlayers);
        }
        public void SavePlayer1StatsToFile(int numberOfPlayers) {
            if (numberOfPlayers == 1)
            {
                Console.WriteLine("\nStats will be saved to file, Good Bye!!!");
                fileWriter.WriteToFile(players[0]);
            }
        }
        public void DisplayStats(int numberOfPlayers) {
            Console.WriteLine("Total Days Played {0}", players[0].DaysPlayed - 1);
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                userInterface.DisplayResults(players[i]);
            }
        }
        public void RunThroughDays(int numberOfPlayers) {
            for (int i = 0; i < numberOfdays; ++i)
            {
                day = new Day();  
                GamePlay(day, numberOfPlayers);     
            }
        }
        public int LoadSavedGame() {
            players.Add(new Human("SavedGame"));
            SavedGameLoader getPlayerAttributes = new SavedGameLoader(players[0]);  
            return 1;
        }
        
        public int UserLoginPrompt(int numberOfPlayers) {
            Console.Write("Player 1 Please Enter Your Name : ");
            players.Add(new Human(Console.ReadLine()));
            Console.Clear();
            if (numberOfPlayers > 1)
            {
                if (numberOfPlayers == 2)
                {
                    Console.Write("Player 2 Please Enter Your Name : ");
                    players.Add(new Human(Console.ReadLine()));
                    Console.Clear();
                    return numberOfPlayers;
                }
                else
                {
                    players.Add(new Computer("Computer"));
                    isComputerPlayer = true;
                    return 2;
                }
            }
            else return 1;
        }
        public void GamePlay(Day day, int numberOfPlayers) {           
            GetInventoryForPlayers(numberOfPlayers, day);
            InteractionWithCustomer(numberOfPlayers);               
            Console.Clear();
            ResultsForTheDay(numberOfPlayers);
            Console.Write("\nPress Enter to Continue:");
            Console.ReadKey(); 
            Console.Clear();
        }
        public void ResultsForTheDay(int numberOfPlayers) {
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                Console.WriteLine("\nToday's Forcast is {0} \nTemperature is {1}", day.Weather.ForcastForToday, day.Weather.Temperature);
                if (players[i].LemonadeStand.IsSoldOut) { Console.WriteLine("\n{0}, Has Sold Out of Lemonade.", players[i].Name); }
                Console.WriteLine("\n{0} Managed to Sell {1} Cups of Lemonade to {2} Potential Customers.", players[i].Name, players[i].LemonadeStand.AmountSold, day.Customers.Count);

                players[i].LemonadeStand.AmountSold = 0;
            }
        }
        public void InteractionWithCustomer(int numberOfPlayers) {
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                Console.WriteLine("Day {0}", players[i].DaysPlayed);
                for (int j = 0; j < day.Customers.Count; ++j)
                {
                    if (!pitcher.IsEmpty())
                    {
                        if (day.Customers[j].BuyLemonade(pitcher.Type, players[i].LemonadeStand))
                        {
                            --pitcher.CupsInPitcher;
                            players[i].CashBox.Money += players[i].LemonadeStand.PricePerCup;
                            players[i].CashBox.Income += players[i].LemonadeStand.PricePerCup;
                            players[i].LemonadeStand.AmountSold += 1;
                            players[i].LemonadeStand.RemoveCupsFromInventory(1, players[i].LemonadeStand.Inventory);
                        }
                    }
                    else
                    {
                        if (players[i].CheckForPitcherIngredientsInInventory(players[i].LemonadeStand.Inventory))
                        {
                            pitcher = players[i].LemonadeStand.MakePitcher(players[i].LemonadeStand.Inventory, players[i]);
                        }
                        else players[i].LemonadeStand.IsSoldOut = true;
                    }
                }
                players[i].DaysPlayed += 1;
            }
        }
        public void GetInventoryForPlayers(int numberOfPlayers, Day day) {
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                if (!isComputerPlayer || i < 1)
                {
                    userInterface.AskPlayerToBuyItems(players[i].LemonadeStand.Inventory, players[i], day);
                    userInterface.PriceAndRecipe(day, players[i].LemonadeStand.Inventory, players[i]);
                }
                else if (isComputerPlayer)
                {
                    players[1].GetInventoryForComputer(day);
                    players[1].GetRecipeForComputer(day);
                }
            }
        }     
    }
}
