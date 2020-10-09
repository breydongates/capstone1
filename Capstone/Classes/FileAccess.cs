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
        private string filePath = @"C:\Catering\cateringSystem.csv"; // File path for csv values to load into catering item
        private string logPath = @"C:\Catering\log.txt"; // File path for log file

        public void LoadCateringItems(Catering catering) // Reads from csv file into cateringitems list
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] type = line.Split("|");        // Splits each line from csv into an array on "|"
                    string priceString = type[2];
                    decimal price = decimal.Parse(priceString);

                    CateringItem Item = new CateringItem(type[1], type[3], type[0], price); // Uses array indexes to grab specific values
                    catering.Add(Item);
                }
            }
        }
        public void TransactionLog(decimal amountAdded, decimal balance) // Writes out to log file when money is addded
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
        public void PurchaseLog(int amountPurchased, string name, string id, decimal price, decimal balance) // Writes out to log file when items are purchased
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine();
                writer.Write(currentTime.ToString());
                writer.Write($" {amountPurchased} {name} {id}  {(price * amountPurchased).ToString("C")} {balance.ToString("C")}");
            }
        }
        public void ChangeLog(decimal changeGiven, decimal balance) // Writes out to log file when change is given
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
