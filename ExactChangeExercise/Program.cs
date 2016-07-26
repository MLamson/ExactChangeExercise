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

        internal static dynamic CheckCashRegister(decimal price, decimal cash, Dictionary<string, decimal> cashInDrawer)
        {
            decimal change = cash - price;
            decimal totalCashInDrawer = 0m;
           
            foreach (var key in cashInDrawer.Keys)
            {
                totalCashInDrawer += cashInDrawer[key];
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

            if (ChangeEqualsTotalCashInDrawer(change, totalCashInDrawer))
            {
                return "Closed";
            }

            foreach (var key in monetaryValues.Keys)
            {
                while (change >= monetaryValues[key] && cashInDrawer[key] != 0)
                {
                    changeTotal[key] += monetaryValues[key];
                  
                    change -= monetaryValues[key];

                    cashInDrawer[key] -= monetaryValues[key];
                }
            }

            if (InsufficientFundsOrWrongDenomination(change, totalCashInDrawer))
            {
                return "Insufficient Funds";
            }

            var changeTotalReturn = changeTotal.Where(changeForDenom => changeForDenom.Value != 0).ToDictionary(pair => pair.Key, pair => pair.Value);
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
