using FelipEcommerce.Application.DAO.Base;

namespace FelipEcommerce.Application.DAO
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public decimal PurshacePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Code { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string Type { get; set; }
    }
}