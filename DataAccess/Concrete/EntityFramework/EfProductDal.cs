using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
            //var result sonuç demek. Ürünler(p) ile kategorileri(c) join ettik.
            //neye göre 'on' a göre, yani CategoryId'leri eşitle.
            //sonucu select ile şu kolonlara uydurarak yaz. süslü parantez içini de alanları yaz, neyi nerden getirdik.
        }
    }
}
