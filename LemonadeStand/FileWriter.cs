using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class FileWriter
    {
        public FileWriter() {}
        public void WriteToFile(Player player) {
            System.IO.StreamWriter file = new System.IO.StreamWriter("SaveGame.txt", true);

            file.WriteLine(player.Name + " " + player.CashBox.Money + " " + player.CashBox.Income + " " + player.CashBox.Expenses);
            file.WriteLine(player.LemonadeStand.Inventory.Cups.Count + " " + player.LemonadeStand.Inventory.Ice.Count + " " + player.LemonadeStand.Inventory.Lemons.Count + " " + player.LemonadeStand.Inventory.Sugar.Count);

            file.WriteLine();

            file.Close();
        }
        /*
         public void SaveStatsToFile(int numberOfPlayers) {
            System.IO.StreamWriter file = new System.IO.StreamWriter("GameStats.txt", true);

            for (int i = 0; i < numberOfPlayers; ++i)
            {
                file.WriteLine("{0}'s gold is now {1}", players[i].GetName(), players[i].GetMoney());
            }
            file.WriteLine();

            file.Close();
        }
         */
    }
}
