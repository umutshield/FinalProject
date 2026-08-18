using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //EfEntityRepositoryBase, IProductDal'ın istediği tüm metotları/operasyonları gerçekleştirir.
    //bu yüzden onları yan yana yazdık.
    //şu anda EfProductDal'da bütün veritabanı operasyonları hazırdır.

    //peki şu an IProductDal'a neden ihtiyacımız var hala?
    //1-Business katmanı hala IProductDal'ı kullanır çünkü yarın entityframework yerine başka bir oracle kullanırsak
    //projenin hata almaması için.
    //2-IProductDal'da ürüne ait özel operasyonlar yazılır (örn. ürünün detaylarını getir).
    
    //aynı mantık ICategoryDal ve diğer entityler içinde geçerlidir.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}
