using CartManagement;
using CartManagement.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static CartManagement.Data.Enum;

namespace CartManagement.UnitTest
{
    [TestClass]
    public class CartTests
    {
        private readonly ICart _cart;
        private readonly Item _item;
        private readonly Promotion _promotion;

        public CartTests()
        {
            this._cart = new Cart();
            this._item = new Item();
            this._promotion = new Promotion();
        }

        [TestMethod]
        public void GetOrderTotal_TotalWithoutPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 2 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 1 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 2 });
            cartItems.Add(new CartItem() { SKU = "D", Quantity = 1 });

            List<Item> allSKUs = this._item.GetAllSKUs();
            int expected = (2 * 50) + (1 * 30) + (2 * 20) + (1 * 15);

            double total = this._cart.GetOrderTotal(cartItems, allSKUs);

            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void CalculateNItemOfferPrice_ApplyNItemPromotion_ReturnOfferPrice()
        {
            int itemQuantity = 5;
            double unitPrice = 50;
            Promotion prom = new Promotion() { Quantity = 3, PromotionType = PromotionType.NItemsPromo, OfferPrice = 130 };
            int expectedResult = 130 + (2 * 50);

            double offerPrice = this._cart.CalculateNItemOfferPrice(itemQuantity, unitPrice, prom);

            Assert.AreEqual(expectedResult, offerPrice);
        }

        [TestMethod]
        public void CheckCombinationExists_CombinationExist_ReturnTrue()
        {
            List<string> compareList = new List<string> { "A", "B", "C" };
            List<string> PromotionSKUs = new List<string> { "A", "B" };

            bool isContains = this._cart.CheckCombinationExists(compareList, PromotionSKUs);

            Assert.IsTrue(isContains);
        }

        [TestMethod]
        public void CheckCombinationExists_CombinationNotExist_ReturnFalse()
        {
            List<string> compareList = new List<string> { "A", "B", "C" };
            List<string> PromotionSKUs = new List<string> { "C", "D" };

            bool isContains = this._cart.CheckCombinationExists(compareList, PromotionSKUs);

            Assert.IsFalse(isContains);
        }

        [TestMethod]
        public void GetOrderTotal_TotalWithnItemPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 1 });

            List<Promotion> promos = this._promotion.GetDefaultPromotions();
            List<Item> allSKUs = this._item.GetAllSKUs();
            int expectedResult = (130 + 2 * 50) + (2 * 45 + 30) + 20;

            double total = this._cart.GetOrderTotal(cartItems, allSKUs, promos);

            Assert.AreEqual(expectedResult, total);
        }

        [TestMethod]
        public void GetOrderTotal_TotalWithComboItemPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 3 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 1 });
            cartItems.Add(new CartItem() { SKU = "D", Quantity = 1 });

            List<Promotion> promos = this._promotion.GetDefaultPromotions();
            List<Item> allSKUs = this._item.GetAllSKUs();
            int expectedResult = (130) + (2 * 45 + 30) + 30;

            double total = this._cart.GetOrderTotal(cartItems, allSKUs, promos);

            Assert.AreEqual(expectedResult, total);
        }
    }
}
