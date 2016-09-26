using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game playGame = new Game();
            playGame.StartGame();
            //Player player = new Human("Buddy");
            //FileReader f = new FileReader();
            //f.ReadFileToAttributes(player);


            Console.Read();
        }
    }
}
