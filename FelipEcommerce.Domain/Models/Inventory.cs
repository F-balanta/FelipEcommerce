using FelipEcommerce.Domain.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipEcommerce.Domain.Models
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "Date")] public DateTime InventoryDate { get; set; }

        public Product Product { get; set; }
    }
}