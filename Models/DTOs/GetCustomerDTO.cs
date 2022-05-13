using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models.DTOs
{
    public class GetCustomerDTO
    {
        public string Login { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
