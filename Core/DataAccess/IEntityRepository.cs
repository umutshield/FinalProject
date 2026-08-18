using Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Bu interface'i neden oluşturduk: Product ve Category interfacelerindeki metotları tek tek yazmamak için oluşturduk
    //bu örnekte Product ve Category entityleri oluşturduk ama büyük bir projeyi düşün çok fazla entity var o zaman ne yapacağız?
    //generic tip kullanıp tüm entitylerde ortak kullanacağımız bir interface oluşturacağız.

    //generic constraint: generic kısıt
    //<T> 'yi yani generic tip'i kısıtlayacağız. buraya sadece entitylerin veri tiplerini gireceğimiz bir filtreleme getireceğiz.
    public interface IEntityRepository<T> where T : class, IEntity, new()    //generic tipimiz, referans tipli(class) olmalı ve bu referans tipler
                                                                            //ya IEntity olmalı ya da IEntity'i implemente eden bir nesne olmalıdır
                                                                           //new() : generic newlenebilir olmalı. IEntity direkt kullanamazsın çünkü interface newlenemez
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);    //Expression, filtreleme görevi görür(LINQ ile kullandık)
        T Get(Expression<Func<T, bool>> filter);        //tek bir data getirmek için ise bu kodu kullanırız(örn. bankada tek bir müşterinin verilerini görmek)
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId);     //ürünleri kategoriye göre filtreler/listele
                                                       //yukarıdaki expression ile bu koda gerek kalmadı
    }
}

//Generic Constraint çalışırken bu bilgileri de edindim : 
//where T : struct: Tür bağımsızı bir değer tipi olmalıdır.
//where T : class: Tür bağımsızı bir referans tipi olmalıdır.
//where T : new(): Tür bağımsızı parametresiz bir kurucuya sahip olmalıdır.
//where T : < base class>: Tür bağımsızı belirtilen temel sınıf olmalı veya ondan türemelidir.
//where T : <interface>: Tür bağımsızı belirtilen arayüzü uygulamalıdır.
