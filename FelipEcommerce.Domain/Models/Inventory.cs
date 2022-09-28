using System;
using FelipEcommerce.Domain.Models.Base;

namespace FelipEcommerce.Domain.Models
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime InventoryDate { get; set; }
        public string Type { get; set; }

        public Product Product { get; set; }
    }
}