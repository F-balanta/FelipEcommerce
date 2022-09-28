using FelipEcommerce.Domain.Models.Base;
using System.Collections.Generic;

namespace FelipEcommerce.Domain.Models
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Invoice> Invonces { get; set; }
    }
}