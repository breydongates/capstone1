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

        private string filePath = @"C:\Catering\cateringLogfile.csv"; // You will likely need to create this folder on your machine

        public void Add(CateringItem item)
        {
            items.Add(item);
        }

        public List<CateringItem> DisplayCateringItems
        {
            get
            {
                return this.items;
            }
        }

        public decimal Balance { get; set; } = 0.0M;

        public void AddMoney(decimal moneyToAdd)
        {
            Balance += moneyToAdd;

        }

        public string SelectProduct(string productCode, int amount)
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
                    item.Quantity -= amount;
                    CateringItem purchasedItem = new CateringItem(item.Name, item.Category, item.Id, item.Price);
                    purchasedItem.Quantity = amount;
                    purchasedItems.Add(purchasedItem);
                    return "Item purchased.";
                }
                
            }
            return "";
        }

        public bool ItemExists(string productCode)
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

        public List<CateringItem> purchasedItems = new List<CateringItem>();

        public decimal CompleteTransaction()
        {
            return 0;
        }

        public string Change(decimal change)
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
