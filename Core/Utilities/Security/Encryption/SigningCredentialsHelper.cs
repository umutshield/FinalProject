using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    /* credentials, bir sisteme girmek için elinizde olan şeylerdir, kullanıcı adı parola gibi.
     * webapi'nin kullanabileceği jwtokenler'ının oluşturulabilmesi için credentials yani anahtarımızı kullanırız. */
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature); 
        }

        /* burada asp.net'e diyorsinki güvenlik anahatarı olarak securityKey'i kullan şifreleme olarakta 
         * güvenlik algoritmalarından HmaSha512'yi kullan. 
         * yani asp.net'e jwt doğrulaması için neleri kullanması gerektiğini söylüyoruz. */
    }
}
