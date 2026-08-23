using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //bu interface hem işlem sonucunu hem mesajını hem de listedeki türü(örneğin Product'ın datasını) döndürür.
    //işlem sonucu ve mesajını önceden yazdığımız için IResult'tan inherit alırız.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
