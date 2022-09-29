using System.Collections.Generic;

namespace FelipEcommerce.Application.DAO
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<InvoiceDto> Invonces { get; set; }
    }
}
