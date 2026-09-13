using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    /* bu interface'te token üretiriz. çalışma mantığı şöyle: kullanıcı, kullanıcı adı ve parolasını girip girişe tıkladğında 
     * datalar webapi'a yollanır. işte tam bu noktada CreateToken operasyonumuz çalışır tabi datalar doğruysa. doğruysa api 
     * ilgili veritabanına gider ve veritabanından bu kullanıcının Claimlarını bulacak. oradan bir tane jwtoken üretecek 
     * ve bu tokenı client'a yollar. */
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
