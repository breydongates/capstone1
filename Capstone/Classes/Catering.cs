using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for a catering system
    /// </summary>
    public class Catering
    {
        private List<CateringItem> items = new List<CateringItem>();

        public void Add(CateringItem item) // Adding the catering item list from file access
        {
            items.Add(item);
        }

        public List<CateringItem> DisplayCateringItems // Display catering items 
        {
            get
            {
                return this.items;
            }
        }

        public decimal Balance { get; set; } = 0.0M; // Money entered, defaults to zero

        public string AddMoney(decimal moneyToAdd) // Add money method
        {
            if (this.Balance >= 5000 || (this.Balance + moneyToAdd) > 5000)
            {
                return "Balance cannot exceed $5000";
                
            }
            if (moneyToAdd < 0)
            {
                return "Can not add negative balance amount, please enter a positive amount";
            }
            else
            {
                this.Balance += moneyToAdd;
                return "Your balance is: " + this.Balance.ToString("C");
            }
            
        }

        public string SelectProduct(string productCode, int amount) // Takes in product code from user input, checks it against codes in catering item list, changes the category, adds them to purchased items list
        {
            foreach (CateringItem item in items)
            {
                if (item.Id == productCode && item.Quantity == 0)
                {
                    return "Item out of stock.";
                }

                if (item.Id == productCode && item.Quantity - amount < 0)
                {
                    return "Not enough stock to complete order.";
                }

                if (item.Id == productCode && item.Quantity > 0)
                {
                    item.Category = CategoryConvert(item.Category);
                    
                    item.Quantity -= amount;
                    CateringItem purchasedItem = new CateringItem(item.Name, item.Category, item.Id, item.Price); // Creates new object of catering item to pass into purchaseditems list
                    purchasedItem.Quantity = amount;

                    purchasedItems.Add(purchasedItem); // Adds item to purchased items list
                    decimal priceTimesAmount = purchasedItem.Quantity * purchasedItem.Price;
                    if (PurchasesOverFiveThousandCheck(priceTimesAmount)) // Calls purchased over 5k to check if shopping cart has exceed max balance
                    {
                        return "Item added to cart. Complete transaction to purchase.";
                    }
                    else
                    {
                        purchasedItems.Remove(purchasedItem);
                        return "Items to purchase exceeds $5000 maximum balance. Item not purchased.";
                    }

                }
                
            }
            return "";
        }

        public bool PurchasesOverFiveThousandCheck(decimal priceTimesAmount) // iterates thru items in purchased item list, adds totals of price*quantity, checks against max balance
        {
            decimal total = 0;
            foreach (CateringItem item in purchasedItems)
            {
                total += item.Price * item.Quantity;
            }
            if (total > 5000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string CategoryConvert(string itemCategory) // takes in category id letter, converts it to full category name
        {
            if (itemCategory == "B")
            {
                return "Beverage";
            }
            if (itemCategory == "E")
            {
                return "Entree";
            }
            if (itemCategory == "D")
            {
                return "Dessert";
            }
            if (itemCategory == "A")
            {
                return "Appetizer";
            }
            return "";
        }

        public bool ItemExists(string productCode) // Checks to see if item exists according to product code
        {
            foreach (CateringItem item in items)
            {
                if (item.Id == productCode)
                {
                    return true;
                }
               
            }
            return false;
        }

        public List<CateringItem> purchasedItems = new List<CateringItem>(); // List of purchased items that we are adding to with select product method

        public bool CheckBalanceIsEnough(decimal total) // Checks total to see if it exceeds available balance
        {
            if (total <= this.Balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Change(decimal change) // Makes change by counting instances of each denomination untill reaching zero
        {   int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickles = 0;
            
            while (change >= 20)
            {
                twenties += 1;
                change -= 20;
            }
            while (change >= 10)
            {
                tens += 1;
                change -= 10;
            }
            while (change >= 5)
            {
                fives += 1;
                change -= 5;
            }
            while (change >= 1)
            {
                ones += 1;
                change -= 1;
            }
            while (change >= 0.25m)
            {
                quarters += 1;
                change -= 0.25m;
            }
            while (change >= 0.10m)
            {
                dimes += 1;
                change -= 0.10m;
            }
            while (change >= 0.05m)
            {
                nickles += 1;
                change -= 0.05m;
            }
            this.Balance = 0;
            return ($"Your change is: {twenties} twenties, {tens} tens, {fives} fives, {ones} ones, {quarters} quarters, {dimes} dimes, and {nickles} nickles. ");
        }
    }

}
