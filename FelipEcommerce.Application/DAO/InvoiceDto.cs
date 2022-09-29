using System;

namespace FelipEcommerce.Application.DAO
{
    public class InvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int Isv { get; set; }
        public int Discount { get; set; }
        public UserDto User { get; set; }
        public ClientDto Client { get; set; }
        public InvoiceDetailDto InvoiceDetail { get; set; }
    }
}