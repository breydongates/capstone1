using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain the definition for one catering item
    /// </summary>
    public class CateringItem
    {
        public CateringItem (string name, string category, int price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

        public int Inventory { get; set; } = 50;

    }
}
