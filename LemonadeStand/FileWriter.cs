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
            System.IO.StreamWriter file = new System.IO.StreamWriter("SaveGame.txt");

            file.Write(player.Name + "+" + player.CashBox.Money + "+" + player.CashBox.Income + "+" + player.CashBox.Expenses + "+" + player.DaysPlayed + "+");
            file.WriteLine(player.LemonadeStand.Inventory.Cups.Count + "+" + player.LemonadeStand.Inventory.Ice.Count + "+" + player.LemonadeStand.Inventory.Lemons.Count + "+" + player.LemonadeStand.Inventory.Sugar.Count);

            file.WriteLine();

            file.Close();
        }
    }
}
