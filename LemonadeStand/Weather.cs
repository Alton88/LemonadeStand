﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LemonadeStand
{    class Weather
    {
        static Random rng;
        int temperature;
        List<string> forcast;
        string forcastForToday;
        public Weather() {
            rng = new Random();
            temperature = rng.Next(50, 100);
            forcast = new List<string>();
            CreateForcast();
            forcastForToday = forcast[rng.Next(4)];
        }
        public int Temperature {
            get { return temperature; }
            set { temperature = value; }
        }
        public string ForcastForToday {
            get { return forcastForToday; }
            set { forcastForToday = value; }
        }
        public void CreateForcast() {
            forcast.Add("Sunny");
            forcast.Add("Partly Cloudy");
            forcast.Add("Overcast");
            forcast.Add("Rainy");
        }
    }
}
