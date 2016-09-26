using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SavedGameLoader
    {
        private FileReader fileReader;
        private string[] savedData;
        private Player player;
        public SavedGameLoader(Player player) {
            fileReader = new FileReader();
            savedData = fileReader.ReadFileToAttributes();
            this.player = player;
            SetPlayer();  
        }
        public void SetPlayer() {
            player.Name = savedData[0];
            player.CashBox.Money = Convert.ToDouble(savedData[1]);
            player.CashBox.Income = Convert.ToDouble(savedData[2]);
            player.CashBox.Expenses = Convert.ToDouble(savedData[3]);
            player.DaysPlayed = Convert.ToInt32(savedData[4]);
            ResetCupInventory(Convert.ToInt32(savedData[5]), player);
            ResetIceInventory(Convert.ToInt32(savedData[6]), player);
            ResetLemonInventory(Convert.ToInt32(savedData[7]), player);
            ResetSugarInventory(Convert.ToInt32(savedData[8]), player);
        }
        public void ResetCupInventory(int numberOfCups, Player player)
        {
            for (int i = 0; i < numberOfCups; ++i)
            {
                player.LemonadeStand.Inventory.Cups.Add(new Cup());
            }
        }
        public void ResetIceInventory(int numberOfIce, Player player)
        {
            for (int i = 0; i < numberOfIce; ++i)
            {
                player.LemonadeStand.Inventory.Ice.Add(new Ice());
            }
        }
        public void ResetLemonInventory(int numberOfLemons, Player player)
        {
            for (int i = 0; i < numberOfLemons; ++i)
            {
                player.LemonadeStand.Inventory.Lemons.Add(new Lemon());
            }
        }
        public void ResetSugarInventory(int numberOfSugar, Player player)
        {
            for (int i = 0; i < numberOfSugar; ++i)
            {
                player.LemonadeStand.Inventory.Sugar.Add(new Sugar());
            }
        }
    }
}
