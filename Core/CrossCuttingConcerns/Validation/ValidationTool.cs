using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);       //Product için bir doğrulama yapıcağım çalışacağım tipte parametreden gelen product'tır
            var result = validator.Validate(context);             //productValidator'u kullanarak yazdığımız kurallar için ilgili context'i(product) doğrula
            if (!result.IsValid)                                         //eğer sonuç geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
