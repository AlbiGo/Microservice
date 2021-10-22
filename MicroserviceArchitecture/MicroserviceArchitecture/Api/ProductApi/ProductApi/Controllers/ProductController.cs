using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Middleware;
using ProductApi.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/product/v1")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IClientMiddleware _IClientMiddleware;
        public ProductController(IClientMiddleware clientMiddleware)
        {
            _IClientMiddleware = clientMiddleware;
        }
        /// <summary>
        /// Action to create a new customer in the database.
        /// </summary>
        /// <param name="CreateClientDTO">Model to create a new client</param>
        /// <returns>Returns the created customer</returns>
        /// <response code="200">Returned if the customer was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>





        /// <summary>
        /// Action to see all existing clients.
        /// </summary>
        /// <returns>Returns a list of all customers</returns>
        /// <response code="200">Returned if the clients were loaded</response>
        /// <response code="400">Returned if the clients couldn't be loaded</response>
        [Route("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            try
            {
                return _IClientMiddleware.GetAlProducts();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetProductPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetProductPrice(string productId)
        {
            try
            {
                return _IClientMiddleware.GetProductPrice(productId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
