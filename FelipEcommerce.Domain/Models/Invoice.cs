using FelipEcommerce.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "Date")] public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Total { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal SubTotal { get; set; }
        public int Isv { get; set; }
        public int Discount { get; set; }

        public User User { get; set; }
        public Client Client { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}