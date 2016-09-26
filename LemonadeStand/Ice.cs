using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice {
        private bool melted; 
        public Ice() {}
        public bool Melted {
            get { return melted; }
            set { melted = value; }
        }
    }
}
