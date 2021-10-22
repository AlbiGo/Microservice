using ClientApi.Data.Entities;
using ClientApi.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.BusinessMapper
{
    public static class Mapper
    {
        public static List<ClientDTO> MappClient(List<Client> clients)
        {
            try
            {
                var businessList = (from  row in clients
                                    select new ClientDTO
                                    {
                                        FirstName = row.FirstName,
                                        LastName = row.LastName,
                                        Birthday = row.Birthday
                                        
                                    }).ToList();


                return businessList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
