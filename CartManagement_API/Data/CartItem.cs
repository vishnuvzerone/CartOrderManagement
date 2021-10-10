#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace CartManagement_API.Data
{
    #region CartItem
    /// <summary>
    /// CartItem
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        public double ActualPrice { get; set; }
        public double OfferPrice { get; set; }
    }
    #endregion CartItem
}
