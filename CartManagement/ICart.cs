﻿using CartManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement
{
    public interface ICart
    {
        double GetOrderTotal(List<CartItem> cartItems, List<Item> items, List<Promotion> promotions = null);

        double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj);

        bool CheckCombinationExists(List<string> compareList, List<string> PromotionSKUs);
    }
}
