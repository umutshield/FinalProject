using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //I interface'i, Product hangi tabloya karşılık geldiğini, Dal(data access layer) ise hangi katmanda olduğunu ifade eder. 
    //IEntityRepository<Product> bu şu demektir: sen IEntityRepository'i Product türü için yapılandırdın.
    //bu interface, Product ile ilgili veritabanında yapılacak operasyonları içeren interfacedir.

    //IProductDal'a neden ihtiyacımız var hala?
    //1-Business katmanı hala IProductDal'ı kullanır çünkü yarın entityframework yerine başka bir oracle kullanırsak
    //projenin hata almaması için.
    //2-IProductDal'da ürüne ait özel operasyonlar yazılır (örn. ürünün detaylarını getir).
    //(aynı mantık ICategoryDal ve diğer entityler içinde geçerlidir.)

    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring : kodun iyileştirilmesi
//DataAccess ve Entities katmanından Core katmanına referans verdik. (DataAccess > Add > Project Reference > Core)
