using FelipEcommerce.Application.DAO.Base;
using System.Collections.Generic;

namespace FelipEcommerce.Application.DAO
{
    public class ClientDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Dni { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public ICollection<InvoiceWithoutClientDto> Invoices { get; set; }
    }
}