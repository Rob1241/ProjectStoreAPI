using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public virtual Address Address { get; set; }
    }
}
