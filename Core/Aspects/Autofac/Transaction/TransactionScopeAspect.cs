using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    /* transaction dediğimiz şey şudur: örneğin sen birine para yolladın senin banka hesabında bir update gerççekleşti 
     * fakat karşı tarafın banka hesabında bir update gerçekleşmedi. senin yolladığın parayı banka hesabına geri 
     * yollama işlemini transaction ile yaparız. */

    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
