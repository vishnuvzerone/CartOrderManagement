#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace CartManagement_API.Data
{
    #region Item
    /// <summary>
    /// Item
    /// </summary>
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
    }
    #endregion Item
}
