using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models.DTOs
{
    public class CreateCustomerDTO
    {
        public string Login { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
