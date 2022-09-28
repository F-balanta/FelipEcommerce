using System;
using System.ComponentModel.DataAnnotations.Schema;
using FelipEcommerce.Domain.Models.Base;

namespace FelipEcommerce.Domain.Models
{
    /// <summary>
    /// Tabla factura
    /// </summary>
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal Total { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal SubTotal { get; set; }
        public int Isv { get; set; }
        public int Discount { get; set; }

        public User User { get; set; }
        public Client Client { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
    }
}