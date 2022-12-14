using FelipEcommerce.Domain.Models.Base;
using System.Collections.Generic;

namespace FelipEcommerce.Domain.Models
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Dni { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}