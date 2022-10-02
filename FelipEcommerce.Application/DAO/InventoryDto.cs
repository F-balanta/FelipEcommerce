using System;
using FelipEcommerce.Application.DAO.Base;

namespace FelipEcommerce.Application.DAO
{
    public class InventoryDto : BaseDto
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime InventoryDate { get; set; }
    }
}