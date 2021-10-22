using ProductApi.Data.Entities;
using ProductApi.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.BusinessMapper
{
    public static class Mapper
    {
        public static List<ProductDTO> MappClient(List<Product> clients)
        {
            try
            {
                var businessList = (from row in clients
                                    select new ProductDTO
                                    {
                                        Name = row.Name,
                                        Description = row.Description,
                                        DateCreated = row.DateCreated,
                                        Category = row.Category

                                    }).ToList();


                return businessList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
