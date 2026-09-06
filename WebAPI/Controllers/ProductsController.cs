using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/* bir controller'ın controller olması için ControllerBase'den inherit alması ve [ApiController] olması lazım.
bu olaya c#'ta attribute denir. */

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]      //[controller]  buraya tarayıcada controller'ın ismi yazılır. örn products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /* Loosely copeld -- gevşek bağımlılık: soyut class'a bağımlılık
        ProductController'ın IProductService'e bağımlılığını tanımlar.
        
        IoC Container -- Inversion of Control -- Değişimin kontrolü
        IoC dediğimiz şeyi bir kutu gibi düşünebilirsin. biz bu kutunun içine new ProductManager, new EfProdutDal gibi
        sonradan kullanacağımız referansları atıp ihtiyaç durumlarında kullanırız. 
        Program.cs>AddControllers'ın altına IoC kodlarımızı yazarıız. */

        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            /* Dependecy chain -- bağımlılık zinciri 
            kodumuzu ProductManager'a yani IProductDal'a yani EfProductDal'a yani entityframework'e bağımlı hale getirtmek istemiyoruz 
            bu yüzden code refactoring yapacağız. eski kod:  IProductService productService = new ProductManager(new EfProductDal()); */

            var result = _productService.GetAll();
            return result.Data;

        }
    }
}
