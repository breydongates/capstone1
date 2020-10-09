using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringSystemTest
    {

        [TestMethod]
        [DataRow("B1", 10, "Item purchased.")]
        [DataRow("D4", 51, "Not enough stock to complete order.")]
        [DataRow("D2", 50, "Item purchased.")]
        public void SelectProductTest(string productCode, int amount, string expected)
        {
            // Arrange
            Catering catering = new Catering();
            FileAccess file = new FileAccess();
            file.LoadCateringItems(catering);

            // Act
            string result = catering.SelectProduct(productCode, amount);

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [DataRow("B", "Beverage")]
        [DataRow("A", "Appetizer")]
        [DataRow("D", "Dessert")]
        [DataRow("M", "")]
        public void SelectProductCategoryTest(string category, string expected)
        {
            // Arrange
            Catering catering = new Catering();
            FileAccess file = new FileAccess();
            file.LoadCateringItems(catering);

            // Act
            string result = catering.CategoryConvert(category);

            // Assert
            Assert.AreEqual(expected, result);

        }

        
        [TestMethod]
        [DataRow("B1", 50, "B1", 50, "Item out of stock.")]
        [DataRow("D4", 50, "D4", 50, "Item out of stock.")]
        public void SelectProductOutOfStock(string productCode, int amount, string productCode2, int amount2, string expected)
        {
            // Arrange
            Catering catering = new Catering();
            FileAccess file = new FileAccess();
            file.LoadCateringItems(catering);
            catering.SelectProduct(productCode, amount);

            // Act
            string result = catering.SelectProduct(productCode2, amount2);

            // Assert
            Assert.AreEqual(expected, result);

        }
        

        [TestMethod]
        public void AddMoneyTest()
        {
            // Arrange
            Catering catering = new Catering();
            decimal amount = 100.0M;
            string expected = "Your balance is: " + amount.ToString("C");

            // Act
            string result = catering.AddMoney(amount);
            

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddMoneyTestNegativeInput()
        {
            // Arrange
            Catering catering = new Catering();
            decimal amount = -100.0M;
            string expected = "Can not add negative balance amount, please enter a positive amount";

            // Act
            string result = catering.AddMoney(amount);


            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddMoneyTestOverFiveThousand()
        {
            // Arrange
            Catering catering = new Catering();
            decimal amount = 6000.00M;
            string expected = "Balance cannot exceed $5000";

            // Act
            string result = catering.AddMoney(amount);


            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("B1", true)]
        [DataRow("F2", false)]
        [DataRow("A5", false)]
        [DataRow("D2", true)]
        [DataRow("25", false)]
        public void ItemExistsTest(string productCode, bool expect)
        {
            // Arrange
            Catering catering = new Catering();
            FileAccess file = new FileAccess();
            file.LoadCateringItems(catering);

            // Act
            bool result = catering.ItemExists(productCode);

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        
        public void ChangeTest()
        {
            // Arrange
            Catering catering = new Catering();
            FileAccess file = new FileAccess();
            file.LoadCateringItems(catering);
            decimal amount = 10.00M;
            string expected = "Your change is: 0 twenties, 1 tens, 0 fives, 0 ones, 0 quarters, 0 dimes, and 0 nickles. ";

            // Act
            string result = catering.Change(amount);

            // Assert
            Assert.AreEqual(expected, result);


        }
    }
}
