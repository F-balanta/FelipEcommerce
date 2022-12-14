using System;
using System.Collections.Generic;
using FelipEcommerce.Domain.Models.Base;

namespace FelipEcommerce.Application.DAO
{
    public class InvoiceWithDetailsWithoutClientDto : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int Isv { get; set; }
        public int Discount { get; set; }

        public UserWithoutInvoicesDto User { get; set; }
        public ICollection<InvoiceDetailWithProductDto> InvoiceDetails { get; set; }
    }
}