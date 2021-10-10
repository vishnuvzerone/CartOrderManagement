using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement_API.Modal
{
    public class Item
    {
        public string SKU { get; set; }
        public int PromotionType { get; set; }
        public int UnitPrice { get; set; }
    }
}
