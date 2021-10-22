using ClientApi.Middleware;
using ClientApi.Models.ResponseDTO;
using ClientApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Mediator
{
    public class ClientMiddleware : IClientMiddleware
    {
        private readonly IClientService _clientService;

        public ClientMiddleware(IClientService clientService)
        {
            _clientService = clientService;
        }

        public List<ClientDTO> GetAllClients()
        {
            try
            {
                var clients = _clientService.GetClients();
                var clientBusiness = BusinessMapper.Mapper.MappClient(clients.ToList());
                return clientBusiness;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
