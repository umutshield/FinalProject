using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    /* validationaspect bir methodinterception'dır. methodinterception, virtual metot içerdiği için validationaspect'ın ezmesi 
     gereken bir metot olmalıdır. o da OnBefore metodudur. */
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))     //validatorType'ın bir IValidator mı. bunun kontrolü if bölmesinde yapılır
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflection??
            //aşağıdaki kodların tamamını teker teker araştır
            var validator = (IValidator)Activator.CreateInstance(_validatorType);        //çalışma anında bir instance oluşturur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);   //metodun(invocation) parametrelerini gez,
                                                                                        //oradaki bir tip benim entityType'imde(product tipinde) ise
            foreach (var entity in entities)                                          //onları validate et yani doğrula
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
