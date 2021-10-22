using ClientApi.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Middleware
{
    public interface IClientMiddleware
    {
        public List<ClientDTO> GetAllClients();

    }
}
