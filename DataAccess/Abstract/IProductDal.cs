using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal       //I interface'i, Product hangi tabloya karşılık geldiğini, 
                                       //Dal(data access layer) ise hangi katmanda olduğunu ifade eder
                                       //bu interface, Product ile ilgili veritabanında yapılacak operasyonları içeren interfacedir
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);     //ürünleri kategoriye göre filtreler/listele
    }
}
