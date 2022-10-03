using FelipEcommerce.Application.DAO.Base;
using System;
using System.Collections.Generic;

namespace FelipEcommerce.Application.DAO
{
    public class InvoiceWhitDetailsWithoutUserDto : BaseDto
    {
        public string InvoiceNumber { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int Isv { get; set; }
        public int Discount { get; set; }

        public ClientDtoWithoutInvoices Client { get; set; }
        public ICollection<InvoiceDetailWithProductDto> InvoiceDetails { get; set; }
    }
}
