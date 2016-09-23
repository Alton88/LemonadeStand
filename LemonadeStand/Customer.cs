using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        static Random randomizer;
        double initalInterest; 
        Weather weather;
        string preference;
        public Customer(int initalInterest, Weather weather, string preference){
            this.initalInterest = initalInterest;
            this.weather = weather;
            randomizer = new Random();
            this.preference = preference;
        }
        public double InitalInterest{
            get { return initalInterest; }
            set { initalInterest = value; }
        }
        public int CheckForTemperaturePreference() {
            if (weather.Temperature <= 100 && weather.Temperature > 90) { return 10; }
             else if (weather.Temperature <= 90 && weather.Temperature > 80) { return 5; }
             else if (weather.Temperature <= 80 && weather.Temperature > 70) { return 0; }
             else if (weather.Temperature <= 70 && weather.Temperature > 60) { return -10; }
             else if (weather.Temperature <= 60 && weather.Temperature > 50) { return -20; }    
             else return -30;
        }
        public int CheckForForcastPreference() {
            if (weather.ForcastForToday == "Sunny") { return 10; }
            else if (weather.ForcastForToday == "Partly Cloudy") { return 5; }
            else if (weather.ForcastForToday == "Overcast") { return -5; }
            else if (weather.ForcastForToday == "Rainy") { return -20; }
            else return -30;
        }
        public int CheckForTastePreference(string pitcherType) {
            if (pitcherType == preference) { return 10; }
            else if (pitcherType == "Weak") { return -10; }
            else return 0;
        }
        public int CheckForPricePreference(double price) {
            if (price > 0.90) { return -15; }
            else if (price <= 0.90 && price > 0.80) { return -5; }
            else if (price <= 0.80 && price > 0.60) { return 0; }
            else if (price <= 0.60 && price > 0.40) { return 10; }
            else return 35;
        }
        public int CheckForIcePreference(int amountOfIce) {
            if (weather.Temperature <= 100 && weather.Temperature > 90 && (amountOfIce >= 5 && amountOfIce < 8)) { return 10; }
            else if (weather.Temperature <= 90 && weather.Temperature > 80 && (amountOfIce >= 5 && amountOfIce < 8)) { return 5; }
            else if (amountOfIce > 8 || amountOfIce < 3) { return -10; }
            return 0;
        }
        public bool BuyLemonade(string pitcherType, LemonadeStand lemonadeStand) {
            int overallInterest = Convert.ToInt32(initalInterest + CheckForTemperaturePreference() + CheckForForcastPreference() + CheckForTastePreference(pitcherType) + CheckForPricePreference(lemonadeStand.PricePerCup)) + CheckForIcePreference(lemonadeStand.IcePerCup);
            int randomNumber = randomizer.Next(60, 80);      
            return randomNumber < overallInterest;
        }
    }
    
}
