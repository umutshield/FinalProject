using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;   //bu nesne class'ın içinde ve metodların dışında tanımlandığında o class için
                                   //bu tip değişkenlere global değişken denir. alt çizgi ile gösterilir.
        public InMemoryProductDal()   //ctor yaz taba bas constructor oluşturur. 
        {
            //gerçek hayatta bu veriler bir Oracle,Sql server, Postgres, MongoDb gibi veritabanlarından alınır
            _products = new List<Product> {  
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);        //business'tan gelen ürün veri tabanına eklenir
        }

        public List<Product> GetAll()
        {
            return _products;             //business'a verilecek ürün listesi. veritabanını döndürür
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;

            //foreach (var p in _products)        //LINQ olmasaydı böyle bir döngü kuracaktık
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //LINQ - Language Integrated Query - Dile Gömülü Sorgu
            //eğerki LINQ olmasaydı biz bir ürünü silmek için listeyi tek tek dolaşıp bir şart koyacaktık.
            //LINQ ile liste bazlı yapıları aynı SQL gibi filtreleyebiliyoruz.

            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);

            //SingleOrDefault() tek bir eleman bulmaya yarar, bizim için _products'ı tek tek dolaşır.
            //SingleOrDefault(p=>) dediğimiz kısım aslında foreach (var p in _products) kısmıdır.
            //SingleOrDefault'ın tamamı ise foreach döngüsünün tamamıdır.
            //SingleOrDefault yerine FirstOrDefault veya First'te kullanılabilir.


            _products.Remove(productToDelete);    //bu kod ile listeden bir şey silinmez, neden peki? product referans tipli olduğu için
                                                 //nasıl sileceğiz peki? id'leri kullanarak ve bunu LINQ ile yaparız.
        }

        public void Update(Product product)   //deleteteki gibi LINQ ile güncelleme yaparız
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;  //güncellemeleri yaptık
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür (p aliastır)
            return _products.Where(p => p.CategoryId == categoryId).ToList();   
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
    