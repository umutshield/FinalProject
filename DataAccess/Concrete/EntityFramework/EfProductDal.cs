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
    public class EfProductDal : IProductDal
    {
        private object context;

        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            //bir class'ı newlediğinde o belleğe garbage collector belli bir aralıkta gelir ve bellekten onu atar.
            //using içerisine yazdığımız nesneler ise using bitince garbage collector'a gelir ve bellekten nesneyi
            //anında atmasını ister. çünkü context nesnesinin bellekte tutulması biraz pahalıdır.
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);    //veri kaynağından product'a ürün eşleştir (referans'ı eşleştir)
                addedEntity.State = EntityState.Added;     //eşleştirilen veriyi ekle. state durum demek yani bu eşleştirmeyi ne yapayım diyor
                context.SaveChanges();                    //ekleme işlemini yap. 

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);    //veri kaynağından product'a ürün eşleştir (referans'ı eşleştir)
                deletedEntity.State = EntityState.Deleted;   //eşleştirilen veriyi sil. state durum demek yani bu eşleştirmeyi ne yapayım diyor
                context.SaveChanges();                      //silme işlemini yap. 

            }  
        }

        public Product Get(Expression<Func<Product, bool>> filter)    //tek data getirir
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();  
                    
                    //filtre null ise tümünü getir değilse --iki noktadan sonrası-- filtreleyip ver.
                    //context.Set<Product> şu anlama gelir: ben Product tablosuyla çalışacağım.
                    //ToList() ise bu tabloyu listeye çevir ve (filtre varsa filtrele) bana ver demektir.
                    //yani kısaca bu satır arka planda SELECET * from Product'ı döndürür.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);   //aynı işlemleri güncelleme için yaptık  
                updatedEntity.State = EntityState.Modified;  
                context.SaveChanges();                      

            }
        }
    }
}
