using FelipEcommerce.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipEcommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public Inventory Inventory { get; set; }
    }
}