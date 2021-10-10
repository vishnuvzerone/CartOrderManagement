#region Included Namespaces
using CartManagement_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CartManagement_API.Utilities.Enums;
#endregion Included Namespaces

namespace CartManagement_API.Services
{
    #region Order
    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        public Order()
        {

        }

        public double GetOrderTotal()
        {
            List<CartItem> cartItems;
            double totalAmount = 0;
            List<Item> items = this.GetAllSKUs();
            List<Promotion> promotions = this.GetAllPromotions();
            cartItems = this.GetCartItems();

            var cartItemDet = from item in items
                              join cart in cartItems on item.SKU equals cart.SKU
                              select new { SKU = item.SKU, UnitPrice = item.UnitPrice, Quantity = cart.Quantity };

            List<CartItem> resultList = new List<CartItem>();
            List<string> compareList = new List<string>();
            foreach (var crtItm in cartItemDet)
            {
                double OfferPrice = 0;
                compareList.Add(crtItm.SKU);
                Promotion promObj = promotions.Where(x => x.SKUs.Contains(crtItm.SKU)).FirstOrDefault();
                if (promObj != null)
                {
                    switch (promObj.PromotionType)
                    {
                        case PromotionType.NItemsPromo:
                            OfferPrice = CalculateNItemOfferPrice(crtItm.Quantity, crtItm.UnitPrice, promObj);
                            break;
                        case PromotionType.ComboPromo:
                            if (CheckCombinationExists(compareList, promObj))
                            {
                                OfferPrice = promObj.OfferPrice;
                            }
                            break;
                    }
                }
                resultList.Add(new CartItem() { SKU = crtItm.SKU, ActualPrice = crtItm.UnitPrice * crtItm.Quantity, Quantity = crtItm.Quantity, OfferPrice = OfferPrice });
            }
            totalAmount = resultList.Sum(x => x.OfferPrice);
            return totalAmount;
        }

        public double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj)
        {
            double xOff = itemQuantity / promObj.Quantity;
            int remaining = itemQuantity % promObj.Quantity;
            return (Math.Floor(xOff) * promObj.OfferPrice) + (remaining * UnitPrice);
        }

        public bool CheckCombinationExists(List<string> compareList, Promotion promObj)
        {
            if (compareList != null && promObj != null)
            {
                return promObj.SKUs.Except(compareList).Count() == 0;
            }
            return false;
        }

        #region GetAllPromotions
        /// <summary>
        /// GetAllPromotions
        /// </summary>
        /// <returns></returns>
        private List<Promotion> GetAllPromotions()
        {
            ////List<PromotionRule> promos = new List<PromotionRule>();
            ////promos.Add(new PromotionRule() { PromotionName = "buy 3 items for a fixed price of 130", PromotionID = 1, PromotionType = PromotionType.FixedAmount, DiscountQuantity = 3, Discount = 130 });
            ////promos.Add(new PromotionRule() { PromotionName = "buy 2 items for a fixed price of 45", PromotionID = 2, PromotionType = PromotionType.FixedAmount, DiscountQuantity = 2, Discount = 45 });
            ////promos.Add(new PromotionRule() { PromotionName = "buy multiple items for a fixed price of 30", PromotionID = 3, PromotionType = PromotionType.FixedAmount, DiscountQuantity = 1, Discount = 30 });
            ////promos.Add(new PromotionRule() { PromotionName = "buy 1 item for a discount of 10%", PromotionID = 4, PromotionType = PromotionType.PercentageDiscount, DiscountQuantity = 1, Discount = 40 });

            List<Promotion> promos = new List<Promotion>();
            promos.Add(new Promotion() { Name = "3 of A's for 130", SKUs = new List<string> { "A" }, Quantity = 3, PromotionType = PromotionType.NItemsPromo, OfferPrice = 130 });
            promos.Add(new Promotion() { Name = "2 of B's for 45", SKUs = new List<string> { "B" }, Quantity = 2, PromotionType = PromotionType.NItemsPromo, OfferPrice = 45 });
            promos.Add(new Promotion() { Name = "C & D for 30", SKUs = new List<string> { "C", "D" }, PromotionType = PromotionType.ComboPromo, OfferPrice = 30 });
            return promos;
        }
        #endregion GetAllPromotions

        #region GetAllSKUs
        /// <summary>
        /// GetAllSKUs
        /// </summary>
        /// <returns></returns>
        private List<Item> GetAllSKUs()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { SKU = "A", UnitPrice = 50 });
            items.Add(new Item() { SKU = "B", UnitPrice = 30 });
            items.Add(new Item() { SKU = "C", UnitPrice = 20 });
            items.Add(new Item() { SKU = "D", UnitPrice = 20 });

            return items;
        }
        #endregion GetAllSKUs

        #region GetCartItems
        /// <summary>
        /// GetCartItems
        /// </summary>
        /// <returns></returns>
        private List<CartItem> GetCartItems()
        {
            List<CartItem> items = new List<CartItem>();
            items.Add(new CartItem() { SKU = "A", Quantity = 3 });
            items.Add(new CartItem() { SKU = "B", Quantity = 5 });
            items.Add(new CartItem() { SKU = "C", Quantity = 1 });
            items.Add(new CartItem() { SKU = "D", Quantity = 1 });

            return items;
        }
        #endregion GetCartItems
    }
    #endregion Order
}
