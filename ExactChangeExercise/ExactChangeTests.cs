using NUnit.Framework;
using System.Collections.Generic;

namespace ExactChangeExercise
{
    [TestFixture]
    class ExactChangeTests
    {
        [Test]
        public void Insufficient_Funds_Message_Returned()
        {
            // Arrange
            decimal price = 19.50m;
            decimal cash = 20.00m;
            Dictionary<string, decimal> cidArray = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 0m}, {"TWENTY", 0m}, {"TEN", 0m}, {"FIVE", 0m},
                {"ONE", 0m}, {"QUARTER", 0m}, {"DIME", 0m},  {"NICKEL", 0m},
                { "PENNY", 0.01m}
            };
            // Act
            string result = Program.checkCashRegister(price, cash, cidArray);

            // Assert
            Assert.AreEqual("Insufficient Funds", result);
        }

        [Test]
        public void Closed_Message_Returned()
        {
            // Arrange
            decimal price = 19.50m;
            decimal cash = 20.00m;
            Dictionary<string, decimal> cidArray = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 0m}, {"TWENTY", 0m}, {"TEN", 0m}, {"FIVE", 0m},
                {"ONE", 0m}, {"QUARTER", 0m}, {"DIME", 0m},  {"NICKEL", 0m},
                { "PENNY", 0.50m}
            };
            // Act
            string result = Program.checkCashRegister(price, cash, cidArray);

            // Assert
            Assert.AreEqual("Closed", result);
        }

        [Test]
        public void Correct_Change_Returned()
        {
            // Arrange
            decimal price = 19.50m;
            decimal cash = 20.00m;
            Dictionary<string, decimal> cidArray = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 100.00m}, {"TWENTY", 60.00m}, {"TEN", 20.00m}, {"FIVE", 55.00m},
                {"ONE", 90.00m}, {"QUARTER", 4.25m}, {"DIME", 3.10m},  {"NICKEL", 2.05m},
                { "PENNY", 1.01m}
            };
            Dictionary<string, decimal> expectedReturnedArray = new Dictionary<string, decimal>
            {
                {"QUARTER", 0.50m}
            };
            // Act
            Dictionary<string, decimal> result = Program.checkCashRegister(price, cash, cidArray);

            // Assert
            CollectionAssert.AreEqual(expectedReturnedArray, result);
        }

        [Test]
        public void Correct_Change_Returned_Multiple_Denominations()
        {
            // Arrange
            decimal price = 3.26m;
            decimal cash = 100.00m;
            Dictionary<string, decimal> cidArray = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 100.00m}, {"TWENTY", 60.00m}, {"TEN", 20.00m}, {"FIVE", 55.00m},
                {"ONE", 90.00m}, {"QUARTER", 4.25m}, {"DIME", 3.10m},  {"NICKEL", 2.05m},
                { "PENNY", 1.01m}
            };
            Dictionary<string, decimal> expectedReturnedArray = new Dictionary<string, decimal>
            {
                {"TWENTY", 60.00m}, {"TEN", 20.00m}, {"FIVE", 15.00m},
                {"ONE", 1.00m}, {"QUARTER", 0.50m}, {"DIME", 0.20m}, { "PENNY", 0.04m}
            };
            // Act
            Dictionary<string, decimal> result = Program.checkCashRegister(price, cash, cidArray);

            // Assert
            CollectionAssert.AreEqual(expectedReturnedArray, result);
        }

        [Test]
        public void Insufficient_Funds_Message_Returned_Wrong_Denominations()
        {
            // Arrange
            decimal price = 19.50m;
            decimal cash = 20.00m;
            Dictionary<string, decimal> cidArray = new Dictionary<string, decimal>
            {
                {"ONE HUNDRED", 0m}, {"TWENTY", 0m}, {"TEN", 0m}, {"FIVE", 0m},
                {"ONE", 1.00m}, {"QUARTER", 0m}, {"DIME", 0m},  {"NICKEL", 0m},
                { "PENNY", 0.01m}
            };
            // Act
            string result = Program.checkCashRegister(price, cash, cidArray);

            // Assert
            Assert.AreEqual("Insufficient Funds", result);
        }
    }
}
