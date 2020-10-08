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
        public CateringItem (string name, string category, string id, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Id = id;
        }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Id { get; set; }
        public decimal Price { get; set; }

        public int Inventory { get; set; } = 50;

    }
}
