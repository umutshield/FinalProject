using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        /* !!Güncelleme: Product gördüğümüz yere TEntity, NorthwindContext gördüğümüz yere TContext yazdık.
        (aşağıdaki metotları EfProductDal classından aldık.)
        burada ne yaptık kısaca: EfEntityReposityorBase adında bir class oluşturduk ve bu class'ı generic tipli yaptık.
        bunu yapmamızın nedeni her entity için add,update vs. metotlarını tek tek yazmamak. */
        public void Add(TEntity entity)
        {
            /* IDisposable pattern implementation of c#
            bir class'ı newlediğinde o belleğe garbage collector belli bir aralıkta gelir ve bellekten onu atar.
            using içerisine yazdığımız nesneler ise using bitince garbage collector'a gelir ve bellekten nesneyi
            anında atmasını ister. çünkü context nesnesinin bellekte tutulması biraz pahalıdır. */

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    
                addedEntity.State = EntityState.Added;      
                context.SaveChanges();                  /* veri kaynağından product'a ürün eşleştir (referans'ı eşleştir) 
                                                         eşleştirilen veriyi ekle. state durum demek yani bu eşleştirmeyi 
                                                         ne yapayım diyor ekleme işlemini yap. */

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);    
                deletedEntity.State = EntityState.Deleted;    
                context.SaveChanges();                    /* veri kaynağından product'a ürün eşleştir (referans'ı eşleştir) 
                                                           eşleştirilen veriyi sil.state durum demek yani bu eşleştirmeyi 
                                                           ne yapayım diyor silme işlemini yap. */

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)    //tek data getirir
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                /* filtre null ise tümünü getir değilse --iki noktadan sonrası-- filtreleyip ver.
                context.Set<TEntity> şu anlama gelir: ben Product tablosuyla çalışacağım.
                ToList() ise bu tabloyu listeye çevir ve (filtre varsa filtrele) bana ver demektir.
                yani kısaca bu satır arka planda SELECET * from Product'ı döndürür. */
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);   //aynı işlemleri güncelleme için yaptık  
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
