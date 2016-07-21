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

        internal static dynamic checkCashRegister(decimal price, decimal cash, Dictionary<string, decimal> cidArray)
        {
            decimal change = cash - price;
            decimal totalCashInDrawer = 0m;
            Dictionary<string, decimal> updatedCashInDrawer = new Dictionary<string, decimal>(cidArray);
           
            foreach (var key in cidArray.Keys)
            {
                totalCashInDrawer += cidArray[key];
            }

            Dictionary<string, decimal> changeArray = new Dictionary<string, decimal>
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

            Dictionary<string, decimal> finalArray = new Dictionary<string, decimal> {};

            if (ChangeEqualsTotalCashInDrawer(change, totalCashInDrawer))
            {
                return "Closed";
            }

            foreach (var key in cidArray.Keys)
            {
                while (change >= monetaryValues[key] && updatedCashInDrawer[key] != 0)
                {
                    changeArray[key] += monetaryValues[key];
                  
                    change -= monetaryValues[key];

                    updatedCashInDrawer[key] -= monetaryValues[key];
                }
            }

            if (InsufficientFundsOrWrongDenomination(change, totalCashInDrawer))
            {
                return "Insufficient Funds";
            }

            for (int i = 0; i < changeArray.Count; i++)
            {
                if (changeArray.ElementAt(i).Value != 0)
                {
                    finalArray.Add(changeArray.ElementAt(i).Key, changeArray.ElementAt(i).Value);
                }
            }
            return finalArray;
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
