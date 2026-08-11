using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>

    //I interface'i, Product hangi tabloya karşılık geldiğini, Dal(data access layer) ise hangi katmanda olduğunu ifade eder. 
    //IEntityRepository<Product> bu şu demektir: sen IEntityRepository'i Product türü için yapılandırdın.
    //bu interface, Product ile ilgili veritabanında yapılacak operasyonları içeren interfacedir.
    {

    }
}
