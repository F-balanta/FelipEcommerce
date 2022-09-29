using FelipEcommerce.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipEcommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurshacePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        public string Code { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string Type { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public Inventory Inventory { get; set; }
    }
}