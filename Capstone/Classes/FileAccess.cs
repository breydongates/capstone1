using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        private string filePath = @"C:\Catering\cateringSystem.csv";
        private string logPath = @"C:\Catering\log.txt";

        public void LoadCateringItems(Catering catering)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] type = line.Split("|");
                    //string[] itemName = type[1].Split("|"); // type [0] is the type, item name [0] is the actual item name
                    //string[] priceSplitter = itemName[1].Split("|");
                    string priceString = type[2];
                    decimal price = decimal.Parse(priceString);

                    CateringItem Item = new CateringItem(type[1], type[3], type[0], price);
                    catering.Add(Item);
                }
            }
        }
        public void TransactionLog(decimal amountAdded, decimal balance)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine();
                writer.Write(currentTime.ToString());
                writer.Write(" ADD MONEY: ");
                writer.Write($" {amountAdded.ToString("C")} {balance.ToString("C")}");
            }
        }
        public void PurchaseLog(int amountPurchased, string name, string id, decimal price, decimal balance)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine();
                writer.Write(currentTime.ToString());
                writer.Write($" {amountPurchased} {name} {id}  {(price * amountPurchased).ToString("C")} {balance.ToString("C")}");
            }
        }
        public void ChangeLog(decimal changeGiven, decimal balance)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine();
                writer.Write(currentTime.ToString());
                writer.Write(" GIVE CHANGE: ");
                writer.Write($" {changeGiven.ToString("C")} {balance.ToString("C")}");
            }
        }
    }
}
