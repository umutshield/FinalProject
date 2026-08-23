using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        /* kısa bir bilgi: ilk paranteze neden bool success yazmadık?
        çünkü bu class true döndüren bir class olduğu için gereksiz kod tekrarına girmemek için yazmadık.  
        bu kod şöyle çalışır: bana bir mesaj ver, ben bu mesajı true bir şekilde base sınıfa yolluyayım.
        bu classta success sabittir fakat message değişken bir bilgidir. */

        //işlem başarılı ve mesajlı hali
        public SuccessResult(string message) : base(true, message)
        {

        }

        //işlem başarılı ve mesajsız hali
        public SuccessResult() : base(true)
        {

        }
    }
}
