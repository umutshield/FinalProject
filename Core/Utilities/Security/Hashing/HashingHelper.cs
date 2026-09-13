using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    //bu class bizim için bir araçtır. bu class hash oluşturmaya ve onu doğrulamaya çalışır.
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash,
            out byte[] passwordSalt)                        //out keywordü, dışarıya verilecek değerdir ve birden fazla veriyi döndürür.
                                                            //kısacası biz bir password vericez ve dışarıya passwordHash ve Salt'ı çıkaracak bir yapı tasarlayacağız.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;                 /* buradaki Key kullandığın algoritmanın oluşturduğu key değeridir. her kullanıcı 
                                                            için bir key oluşur. sonradan bu keyi değiştirebilirsin. */
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //kısacası bu kod verdiğiniz bir password değerinin hash ve salt değerini oluşturmaya yarar.

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)    /* passwordhash'i doğrulama. burada hash karşılaştırması yapıyoruz. ne demek hash karşılaştırması?
                                                                                                             * kullanıcının sonradan tekrar girdiği string password, aynı algoritmayı kullanarak bizim  
                                                                                                             * veritabanımızdaki byte[] passwordHash ile eşleşiyor mu. bunu kontrol ederiz.
                                                                                                             * burada out'a gerek yok çünkü değerleri biz vereceğiz.  */
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));      //computedHash, hesaplama hashi demek. computedHash ile kullanıcının girdiği password'ü karşılaştırmamız lazım.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])         //değerler birbiriyle eşleşmeze false döndür
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
