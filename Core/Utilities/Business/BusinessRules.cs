using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)  /* params, Run içinde istediğin kadar IResult türünde parametre vermeni sağlar. 
                                                             * c# arka planda gönderdiğiniz parametreleri array haline getirir ve IResult'a atar. 
                                                             * logics, iş kuralı demek. */
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
