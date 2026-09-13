using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    /* şifreleme olan sistemlerde her şeyi bir byte[] formatında oluşturmamız gerekiyor.
     * örneğin bizim appsetting.json'da yazdığımız "mysupersecretkeymysupersecretkey" key'ini 
     * jwt'nin anlayacağı formata çevirmemiz gerekiyor.  */

    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)      
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }


        /* HashingHelper'da password için yaptığımız şeyin aynısını burada yapıyoruz. 
         * bana bir tane securityKey ver bende onun SecurityKey karşılığını sana vereyim.  */
    }
}
