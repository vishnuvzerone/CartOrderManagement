#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace CartManagement_API.Utilities
{
    #region Enums
    /// <summary>
    /// Enums
    /// </summary>
    public class Enums
    {
        #region PromotionType
        /// <summary>
        /// PromotionType
        /// </summary>
        public enum PromotionType
        {
            /// <summary>
            /// FixedAmount
            /// </summary>
            NItemsPromo = 1,

            /// <summary>
            /// PercentageDiscount
            /// </summary>
            ComboPromo = 2,

            PercentagePromo = 3
        }
        #endregion PromotionType
    }
    #endregion Enums
}
