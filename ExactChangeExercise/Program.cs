using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactChangeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        internal static dynamic CheckCashRegister(decimal price, decimal cash, Dictionary<string, decimal> cashInDrawerInitial)
        {
            decimal change = cash - price;
            decimal totalCashInDrawer = 0m;
            Dictionary<string, decimal> updatedCashInDrawer = new Dictionary<string, decimal>(cashInDrawerInitial);
           
            foreach (var key in cashInDrawerInitial.Keys)
            {
                totalCashInDrawer += cashInDrawerInitial[key];
            }

            Dictionary<string, decimal> changeTotal = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 0m}, {"TWENTY", 0m}, {"TEN", 0m}, {"FIVE", 0m},
                {"ONE", 0m}, {"QUARTER", 0m}, {"DIME", 0m},  {"NICKEL", 0m},
                { "PENNY", 0m}
            };

            Dictionary<string, decimal> monetaryValues = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 100.00m}, {"TWENTY", 20.00m}, {"TEN", 10.00m}, {"FIVE", 5.00m},
                {"ONE", 1.00m}, {"QUARTER", 0.25m}, {"DIME", 0.10m},  {"NICKEL", 0.05m},
                { "PENNY", 0.01m}
            };

            Dictionary<string, decimal> changeTotalReturn = new Dictionary<string, decimal> {};

            if (ChangeEqualsTotalCashInDrawer(change, totalCashInDrawer))
            {
                return "Closed";
            }

            foreach (var key in cashInDrawerInitial.Keys)
            {
                while (change >= monetaryValues[key] && updatedCashInDrawer[key] != 0)
                {
                    changeTotal[key] += monetaryValues[key];
                  
                    change -= monetaryValues[key];

                    updatedCashInDrawer[key] -= monetaryValues[key];
                }
            }

            if (InsufficientFundsOrWrongDenomination(change, totalCashInDrawer))
            {
                return "Insufficient Funds";
            }

            for (int i = 0; i < changeTotal.Count; i++)
            {
                if (changeTotal.ElementAt(i).Value != 0)
                {
                    changeTotalReturn.Add(changeTotal.ElementAt(i).Key, changeTotal.ElementAt(i).Value);
                }
            }
            return changeTotalReturn;
        }

        private static bool ChangeEqualsTotalCashInDrawer(decimal change, decimal totalCashInDrawer)
        {
            return change == totalCashInDrawer;
        }

        private static bool InsufficientFundsOrWrongDenomination(decimal change, decimal cashInDrawer)
        {
            return change > cashInDrawer || change != 0;
        }
    }
}
