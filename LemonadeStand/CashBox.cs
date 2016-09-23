using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CashBox
    {
        double money;
        double income;
        double expenses;
        double inventoryValue;
        double netProfit;

        public CashBox(){
            money = 20;
        }
        public double Money{
            get { return money; }
            set { money = value; }
        }
        public double Income{
            get { return income; }
            set { income = value; }
        }
        public double Expenses{
            get { return expenses; }
            set { expenses = value; }
        }
        public double InventoryValue{
            get { return inventoryValue; }
            set { inventoryValue = value; }
        }
        public double NetProfit{
            get { return income - expenses; }
            set { netProfit = value; }
        }
    }
}
