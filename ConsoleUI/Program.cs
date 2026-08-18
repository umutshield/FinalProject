using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //InMemoryProductDal'ı EfProductDal ile değiştirip çalıştırdık ve başka hiçbir değişiklik yapmadan
    //uygulama çalıştı.sonuç olarak ürünlerin adını verdi.
    //Bu olay SOLID'de O ya(open closed princeple) denk gelir. yani sen yaptığın yazılıma yeni bir özellik
    //ekliyorsan mevcuttaki hiçbir koduna dokunamazsın.
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            //productManager.GetAll()  bundan sonra buraya neyin yazmasını istiyorsak yazabiliriz.
            //örn: productManager.GetAllByCategoryId(2) yazarsak kategori id'si 2 olan ürünleri yazdıracak.

            foreach (var product in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
} 
