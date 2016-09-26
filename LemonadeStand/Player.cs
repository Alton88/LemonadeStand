using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {
        private string name;
        private CashBox cashBox;
        private LemonadeStand lemonadeStand;
        private int daysPlayed;

        public Player(string name) {
            this.name = name;
            cashBox = new CashBox();
            lemonadeStand = new LemonadeStand();
            daysPlayed = 1;
        }
        public virtual int DaysPlayed {
            get { return daysPlayed; }
            set { daysPlayed = value; }
        }
        public virtual LemonadeStand LemonadeStand{
            get { return lemonadeStand; }
            set { lemonadeStand = value; }
        }
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }  
        public virtual CashBox CashBox {
            get { return cashBox; }
            set { cashBox = value; }
        }
        public virtual bool CheckForPitcherIngredientsInInventory(Inventory inventory)
        {
            if (inventory.Lemons.Count >= 5 && inventory.Sugar.Count >= 5 && inventory.Ice.Count >= 60 && inventory.Cups.Count >= 12)
            {
                return true;
            }
            else
                return false;
        }
        public virtual void GetInventoryForComputer(Day day) { }
        public virtual void GetRecipeForComputer(Day day) { }
        }
    }
