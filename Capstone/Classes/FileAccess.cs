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

        public void LoadCateringItems()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] type = line.Split("|");
                    string[] itemName = type[1].Split("|"); // type [0] is the type, item name [0] is the actual item name
                    string[] priceSplitter = itemName[1].Split("|");
                    int price = int.Parse(itemName[0]);
                    
                }
            }
        }
    }
}
