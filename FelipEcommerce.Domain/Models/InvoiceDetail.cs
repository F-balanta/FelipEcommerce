using System.ComponentModel.DataAnnotations.Schema;
using FelipEcommerce.Domain.Models.Base;

namespace FelipEcommerce.Domain.Models
{
    public class InvoiceDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int InvoiceId { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}
