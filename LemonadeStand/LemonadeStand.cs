using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LemonadeStand
    {
        double pricePerCup;
        int lemonsPerPitcher;
        int sugarPerPitcher;
        int icePerCup;
        int cupsPerPitcher;
        int amountSold;
        bool isSoldOut;
        Inventory inventory;

        public LemonadeStand() {
            cupsPerPitcher = 12;
            inventory = new Inventory();
        }
        public Inventory Inventory {
            get { return inventory; }
            set { inventory = value; }
        }
        public int AmountSold
        {
            get { return amountSold; }
            set { amountSold = value; }
        }
        public double PricePerCup
        {
            get { return pricePerCup; }
            set { pricePerCup = value; }
        }
        public int LemonsPerPitcher
        {
            get { return lemonsPerPitcher; }
            set { lemonsPerPitcher = value; }
        }
        public int SugarPerPitcher
        {
            get { return sugarPerPitcher; }
            set { sugarPerPitcher = value; }
        }
        public int IcePerCup
        {
            get { return icePerCup; }
            set { icePerCup = value; }
        }
        public bool IsSoldOut {
            get { return isSoldOut; }
            set { isSoldOut = value; }
        }
        public Pitcher MakePitcher(Inventory inventory, Player player)
        {
            RemoveLemonsFromInventory(lemonsPerPitcher, inventory);
            RemoveSugarFromInventory(sugarPerPitcher, inventory);
            RemoveIceFromInventory(icePerCup * 12, inventory);
            //RemoveCupsFromInventory(12, inventory);
            isSoldOut = false;
            return new Pitcher(DetermineType(), cupsPerPitcher);
        }
        public void RemoveLemonsFromInventory(int amount, Inventory inventory)
        {
            if (amount <= inventory.Lemons.Count)
            {
                for (int i = 0; i < amount; ++i)
                {
                    inventory.Lemons.RemoveAt(inventory.Lemons.Count - 1);
                }
            }
        }
        public void RemoveSugarFromInventory(int amount, Inventory inventory)
        {
            if (amount <= inventory.Sugar.Count)
            {
                for (int i = 0; i < amount; ++i)
                {
                    inventory.Sugar.RemoveAt(inventory.Sugar.Count - 1);
                }
            }
        }
        public void RemoveIceFromInventory(int amount, Inventory inventory)
        {
            if (amount <= inventory.Ice.Count)
            {
                for (int i = 0; i < amount; ++i)
                {
                    inventory.Ice.RemoveAt(inventory.Ice.Count - 1);
                }
            }
        }
        public void RemoveCupsFromInventory(int amount, Inventory inventory)
        {
            if (amount <= inventory.Cups.Count)
            {
                for (int i = 0; i < amount; ++i)
                {
                    inventory.Cups.RemoveAt(inventory.Cups.Count - 1);
                }
            }
        }
        public string DetermineType()
        {
            if (lemonsPerPitcher < 5 || sugarPerPitcher < 5) { return "Weak"; }
            else if (lemonsPerPitcher == sugarPerPitcher) { return "Balanced"; }
            else if (lemonsPerPitcher > sugarPerPitcher + 1) { return "Tart"; }
            else if (lemonsPerPitcher + 1 < sugarPerPitcher) { return "Sweet"; }
            else return "Regular";
        }
    }
}
