using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Computer : Player
    {
        public Computer(string name) : base(name) { }
        public override void GetInventoryForComputer(Day day)
        {
            Store store = new Store();
            if (this.LemonadeStand.Inventory.Cups.Count < 100) { store.CupCheckout(100, 3.23, this.LemonadeStand.Inventory, this); }
            if (this.LemonadeStand.Inventory.Lemons.Count < 55) { store.LemonCheckout(75, 4.45, this.LemonadeStand.Inventory, this); }
            if (this.LemonadeStand.Inventory.Sugar.Count < 55) { store.SugarCheckout(100, 3.41, this.LemonadeStand.Inventory, this); }
            if (this.LemonadeStand.Inventory.Ice.Count < 500) { store.IceCheckout(500, 3.61, this.LemonadeStand.Inventory, this); }
        }
        public override void GetRecipeForComputer(Day day)
        {
            if (day.Weather.Temperature > 80) { this.LemonadeStand.PricePerCup = 0.80; }
            else if (day.Weather.Temperature > 70) { this.LemonadeStand.PricePerCup = 0.70; }
            else if (day.Weather.Temperature > 60) { this.LemonadeStand.PricePerCup = 0.60; }
            else this.LemonadeStand.PricePerCup = 0.35;

            this.LemonadeStand.LemonsPerPitcher = 5;
            this.LemonadeStand.SugarPerPitcher = 5;
            this.LemonadeStand.IcePerCup = 5;
        }
    }
}
