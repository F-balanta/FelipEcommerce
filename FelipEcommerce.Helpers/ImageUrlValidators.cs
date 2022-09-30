using System.Net;
using System.Text.RegularExpressions;

namespace FelipEcommerce.Helpers
{
    public class ImageUrlValidators
    {
        private const string ValidationOne =
            @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private const string ValidationTwo =
            @"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private static bool ValidImgFormat(string img)
        {
            if (Regex.IsMatch(img, ValidationOne))
                return true;
            else if
                (Regex.IsMatch(img, ValidationTwo)) return true;
            else
                return false;
        }

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

        public static bool ImgUrlIsValid(string img)
        {
            bool imgIsValid = ValidImgFormat(img);
            return imgIsValid && DoesImageExistRemotely(img);
        }
    }
}