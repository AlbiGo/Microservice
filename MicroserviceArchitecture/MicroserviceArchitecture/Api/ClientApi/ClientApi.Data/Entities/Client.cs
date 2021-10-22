using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Data.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public Client()
        {
            if(Birthday != null)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                var span = DateTime.Now.Year - Birthday.Value.Year;
                Age = span - 1;
            }
         
        }
    }
    
}
