using FelipEcommerce.Application.DAO.Base;

namespace FelipEcommerce.Application.DAO
{
    public class UserWithoutInvoicesDto : BaseDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}