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
                if (item.Id == productCode && item.Inventory == 0)
                {
                    return "Item out of stock.";
                }

                if (item.Id == productCode && item.Inventory - amount < 0)
                {
                    return "Not enough stock to complete order.";
                }

                if (item.Id == productCode && item.Inventory > 0)
                {
                    item.Inventory -= amount;
                    return "Item purchased.";
                }
                
            }
            return "";
        }
   
    }
}
