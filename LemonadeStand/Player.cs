using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {
        string name;
        CashBox cashBox;
        LemonadeStand lemonadeStand;

        public Player(string name) {
            this.name = name;
            cashBox = new CashBox();
            lemonadeStand = new LemonadeStand();
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
        }
    }
