using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CartManagement_API.Utilities.Enums;

namespace CartManagement_API.Data
{
    public class Promotion
    {
        public string Name { get; set; }
        public List<string> SKUs { get; set; }
        public PromotionType PromotionType { get; set; }
        public int Quantity { get; set; }
        public double OfferPrice { get; set; }
    }
}
