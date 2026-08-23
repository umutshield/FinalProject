using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //sadece veriyi false bir şekilde(başarısız) base sınıfına yollar
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //datayı default(veri yok) haliyle döndürür ve base'e mesaj yollar
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
