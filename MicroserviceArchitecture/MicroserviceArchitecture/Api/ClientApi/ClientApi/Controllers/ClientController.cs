using ClientApi.Middleware;
using ClientApi.Models.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/client/v1")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientMiddleware _IClientMiddleware;
        public ClientController(IClientMiddleware clientMiddleware)
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
        [Route("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetClients()
        {
            try
            {
                return  _IClientMiddleware.GetAllClients();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
