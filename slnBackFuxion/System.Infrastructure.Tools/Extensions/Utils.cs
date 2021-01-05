using System.Globalization;
using System.Text.RegularExpressions;

namespace System.Infrastructure.Tools.Extensions
{
    public class Utils
    {
        //Variables privadas
        bool invalid = false;

        //Métodos
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
