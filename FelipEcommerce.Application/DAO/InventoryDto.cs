using System;

namespace FelipEcommerce.Application.DAO
{
    public class InventoryDto
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime InventoryDate { get; set; }
        public string Type { get; set; }
        public ProductDto Product { get; set; }
    }
}