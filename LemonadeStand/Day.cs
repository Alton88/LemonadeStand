using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        List<Customer> customers;
        Weather weather;
        Random rng;
        List<string> customerPreference;
        int count;
        public Day() {
            rng = new Random();
            customers = new List<Customer>();
            weather = new Weather();
            customerPreference = new List<string>(){"Balanced", "Tart", "Sweet"};
            CreateCustomers();
        }
        public int Count {
            get { return count; }
            set { count = value; }
        }
        public List<Customer> Customers {
            get { return customers; }
            set { customers = value; }
        }
        public void CreateCustomers(){
            for (int i = 0; i < 100; ++i){
                customers.Add(new Customer(rng.Next(50, 90), weather, customerPreference[rng.Next(0,3)]));
            }
        }
        public Weather Weather {
            get { return weather; }
            set { weather = value; }
        }
    }//End of class
}
