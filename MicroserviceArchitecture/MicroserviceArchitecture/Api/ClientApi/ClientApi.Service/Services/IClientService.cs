using ClientApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientApi.Service.Services
{
    public interface IClientService
    {
        Task<Client> CreateClient(Client client);
        public IEnumerable<Client> GetClients();


    }
}
