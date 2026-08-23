using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        /* kısa bir bilgi: ilk paranteze neden bool success yazmadık?
        çünkü bu class true döndüren bir class olduğu için gereksiz kod tekrarına girmemek için yazmadık.  
        aşağıdaki kod şöyle çalışır: bana bir data ve mesaj ver, ben bu bilgileri true bir şekilde base sınıfa yolluyayım.
        (bu classta success sabittir fakat message değişkenlik gösteren bir bilgidir.) */
        public SuccessDataResult(T data, string message):base(data, true, message)
        {
            
        }

        //sadece veriyi true bir şekilde(başarılı) base sınıfına yollar
        public SuccessDataResult(T data):base(data, true)
        {
            
        }

        //datayı default(veri yok) haliyle döndürür ve base'e mesaj yollar
        public SuccessDataResult(string message):base(default, true, message)
        {
            
        }

        public SuccessDataResult():base(default, true)
        {
            
        }
    }
}
