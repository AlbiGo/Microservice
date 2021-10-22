using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Middleware
{
    public interface IOrderMiddleware
    {
        public  Task CheckOut();

    }
}
