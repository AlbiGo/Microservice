using ClientApi.Data.Entities;
using ClientApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientApi.Service.Services
{
    public class ClientService : IClientService
    {
        private IRepository<Client> _clientRepository;
        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateClient(Client client)
        {
            try
            {
                var resutl =  this._clientRepository.AddAsync(client);
                return await resutl;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public  IEnumerable<Client> GetClients()
        {
            try
            {
                var resutl = this._clientRepository.GetAll();
                return resutl ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
