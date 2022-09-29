using System.Collections.Generic;
using FelipEcommerce.Application.DAO.Base;

namespace FelipEcommerce.Application.DAO
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public ICollection<InvoiceWithoutUserDto> Invoices { get; set; }
    }
}
