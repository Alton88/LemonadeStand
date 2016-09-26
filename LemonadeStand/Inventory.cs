using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        private List<Lemon> lemons;
        private List<Sugar> sugar;
        private List<Ice> ice;
        private List<Cup> cups;

        public Inventory()
        {
            lemons = new List<Lemon>();
            sugar = new List<Sugar>();
            ice = new List<Ice>();
            cups = new List<Cup>();
        }
        public List<Lemon> Lemons
        {
            get { return lemons; }
            set { lemons = value; }
        }
        public List<Sugar> Sugar
        {
            get { return sugar; }
            set { sugar = value; }
        }
        public List<Ice> Ice
        {
            get { return ice; }
            set { ice = value; }
        }
        public List<Cup> Cups
        {
            get { return cups; }
            set { cups = value; }
        }
    }
}
