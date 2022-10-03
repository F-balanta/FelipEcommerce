using FelipEcommerce.Application.DAO.Base;

namespace FelipEcommerce.Application.DAO
{
    public class InvoiceDetailWithProductDto : BaseDto
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int InvoiceId { get; set; }

        public ProductDto Product { get; set; }
    }
}