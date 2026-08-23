using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /*
    Temel voidler için başlangıç
    biz buraya bir tane işlem(Add) sonucu ve bu işlem sonucunu kullanıcıya bilgilendirmek için bir mesaj yazacağız.
    amaç uygulamamızı kullanacak kullanıcıları doğru yönlendirmektir.
    (bundan sonra void gördüğümüz yere IResult yazarız.)    
    */
    public interface IResult
    {
        bool Success { get; }    //get; okunabilmek set; yazabilmek için kullanılır. burada sadece get; kullandık.
        string Message { get; }

    }
}
