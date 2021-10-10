using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CartManagement.Data.Enum;

namespace CartManagement.Data
{
    public class Promotion
    {
        public string Name { get; set; }
        public List<string> SKUs { get; set; }
        public PromotionType PromotionType { get; set; }
        public int Quantity { get; set; }
        public double OfferPrice { get; set; }

        public List<Promotion> GetDefaultPromotions()
        {
            List<Promotion> promos = new List<Promotion>();
            promos.Add(new Promotion() { Name = "3 of A's for 130", SKUs = new List<string> { "A" }, Quantity = 3, PromotionType = PromotionType.NItemsPromo, OfferPrice = 130 });
            promos.Add(new Promotion() { Name = "2 of B's for 45", SKUs = new List<string> { "B" }, Quantity = 2, PromotionType = PromotionType.NItemsPromo, OfferPrice = 45 });
            promos.Add(new Promotion() { Name = "C & D for 30", SKUs = new List<string> { "C", "D" }, PromotionType = PromotionType.ComboPromo, OfferPrice = 30 });
            return promos;
        }
    }
}
