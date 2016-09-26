using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CashBox
    {
        private double money;
        private double income;
        private double expenses;
        private double netProfit;

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
        public double NetProfit{
            get { return income - expenses; }
            set { netProfit = value; }
        }
    }
}
