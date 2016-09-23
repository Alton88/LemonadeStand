using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Pitcher {
        int cupsInPitcher;
        string type; 
        
        public Pitcher(string type, int cupsInPitcher) {
            this.cupsInPitcher = cupsInPitcher;
            this.type = type;
        }
        public int CupsInPitcher{
            get { return cupsInPitcher; }
            set { cupsInPitcher = value; }
        }
        public string Type {
            get { return type; }
            set { type = value; }
        }
        public bool IsEmpty() {
            return cupsInPitcher > 0 ? false : true;
        }
    }
}
