using ClientApi.Data.Database;
using ClientApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ClientContext clientContext) : base(clientContext)
        {
        }
        public async Task<Client> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _clientContext.Customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
