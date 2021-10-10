#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartManagement_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
#endregion Included Namespaces

namespace CartManagement_API.Controllers
{
    #region CartController
    /// <summary>
    /// CartController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region CartController
        /// <summary>
        /// CartController
        /// </summary>
        public CartController()
        {

        }
        #endregion CartController
        
        [HttpGet]
        public void Get()
        {
            Order ord = new Order();
            ord.GetOrderTotal();
        }

        ////public void Post([FromForm] )
        ////{

        ////}
    }
    #endregion CartController
}
