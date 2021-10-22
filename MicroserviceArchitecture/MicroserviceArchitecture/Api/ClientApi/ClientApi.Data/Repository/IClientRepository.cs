using ClientApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Data.Repository
{
    public interface IClientRepository
    {
        Task<Client> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);

    }
}
