#region Incuded Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CartManagement_API.Utilities.Enums;
#endregion Incuded Namespaces

namespace CartManagement_API.Data
{
    #region PromotionRule
    /// <summary>
    /// Promotion Rule
    /// </summary>
    public class PromotionRule
    {
        /// <summary>
        /// RuleID
        /// </summary>
        public int PromotionID { get; set; }

        /// <summary>
        /// PromotionName
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// PromotionType
        /// </summary>
        public PromotionType PromotionType { get; set; }

        /// <summary>
        /// Minimum Quantity For Discount
        /// </summary>
        public int DiscountQuantity { get; set; }

        /// <summary>
        /// Fixed Amount or Discount Percentage
        /// </summary>
        public double Discount { get; set; }
    }
    #endregion PromotionRule
}
