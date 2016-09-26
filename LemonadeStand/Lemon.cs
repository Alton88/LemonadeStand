using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon{
        bool spoiled;
        public Lemon() {

        }
        public bool Spoiled{
            get { return spoiled; }
            set { spoiled = value; }
        }
    }
}
