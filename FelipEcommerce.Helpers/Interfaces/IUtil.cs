namespace FelipEcommerce.Helpers.Interfaces
{
    public interface IUtil
    {
        bool ImgUrlIsValid(string img);
        string GenerateInvoiceNumber();
        decimal GeneratePriceWithIva(int qty, decimal price, int iva);
        decimal GetSimplePrice(int qty, decimal price);
        decimal GeneratePriceFinal(int qty, decimal price, int discount, int iva);
    }
}