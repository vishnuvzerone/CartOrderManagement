using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Data
{
    public class Item
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// UnitPrice
        /// </summary>
        public double UnitPrice { get; set; }

        #region GetAllSKUs
        /// <summary>
        /// GetAllSKUs
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllSKUs()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { SKU = "A", UnitPrice = 50 });
            items.Add(new Item() { SKU = "B", UnitPrice = 30 });
            items.Add(new Item() { SKU = "C", UnitPrice = 20 });
            items.Add(new Item() { SKU = "D", UnitPrice = 15 });

            return items;
        }
        #endregion GetAllSKUs
    }
}
