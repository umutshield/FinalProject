using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();          //List<Product> > IDataResult<List<Product>>
                                                      //önceden biz sadece datayı döndürürdük şimdiyse işlemi ve mesajını da döndürüyoruz
        IDataResult<List<Product>> GetAllByCategoryId(int id);          //GetAllBy şarta uyanların tümünü getir
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);  //GetBy eşsiz verileri ya da tek bir veriyi isterken kullanılır
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);    //burada product'ı neden liste içine almadık. çünkü örn 1 nolu id'e sahip 
                                                        //tek bir product vardır. bu yüzden listeyi döndürmemize gerek yoktur.
        IResult Add(Product product);    /* buradaki Add metodu ile DataAccess'te yazdığımız Add metodu tamamen farklı. businessta
                                         bir nevi sorgu yapıyoruz. örneğin bir ürün mü eklenecek business katmanı soruyor bu
                                         ürünün fiyatı 0 tlden büyük mü veya sisteme daha önceden kayıtlı mı. ProductManager'da
                                         sürekli yazdığımız iş kodları işte bu sorgulardır. eğer ürün business katmanından onay
                                         alırsa DataAccess'e yollanır ve oradan veritabanına Add edilir. (void > IResult) */
        
    }
}
