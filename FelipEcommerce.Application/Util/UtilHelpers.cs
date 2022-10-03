using FelipEcommerce.Helpers.Interfaces;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace FelipEcommerce.Application.Util
{
    public class UtilHelpers : IUtil
    {
        public bool ImgUrlIsValid(string img)
        {
            var imgIsValid = ValidImgFormat(img);
            return imgIsValid && DoesImageExistRemotely(img);
        }

        public string GenerateInvoiceNumber()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path[..10].ToUpper();
        }

        public decimal GetSimplePrice(int qty, decimal price) => price * qty;

        public decimal GeneratePriceWithIva(int qty, decimal price, int iva)
        {
            if (iva <= 0) return qty * price;
            var priceTotal = price * qty;
            var sumaIva = (priceTotal * iva) / 100;
            return sumaIva + price;
        }

        public decimal GeneratePriceFinal(int qty, decimal price, int discount, int iva)
        {
            if (discount <= 0)
                return GeneratePriceWithIva(qty, price, iva);

            decimal priceTotal = price * qty;
            decimal ivaTotal = (priceTotal * iva) / 100;
            decimal sumaIva = ivaTotal + priceTotal;
            decimal restaDiscount = (sumaIva * discount) / 100;
            return sumaIva - restaDiscount;
        }

        private const string ValidationOne =
            @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private const string ValidationTwo =
            @"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private static bool ValidImgFormat(string img) =>
            Regex.IsMatch(img, ValidationOne) || Regex.IsMatch(img, ValidationTwo);

        private static bool DoesImageExistRemotely(string uriToImage)
        {
            var request = (HttpWebRequest)WebRequest.Create(uriToImage);
            request.Method = "HEAD";

            try
            {
                using var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}