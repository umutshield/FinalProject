using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /* this demek classın kendisi demek burda Result'ı temsil eder. this(success) demek Result'ın tek parametreli 
        constructorına success'i yolla demektir. bu da şu anlama gelir: message çalıştığında aynı zamanda success'te 
        çalışsın fakat success tek çalıştığında message çalışmasın. */
        public Result(bool success, string message):this(success)  
        {
            Message = message;      //get'ler constructorda set; edilebilir       
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
