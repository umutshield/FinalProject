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
        Program.cs>AddControllers'ın altına IoC kodlarımızı yazarız. */

        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            /* Dependecy chain -- bağımlılık zinciri 
            kodumuzu ProductManager'a yani IProductDal'a yani EfProductDal'a yani entityframework'e bağımlı hale getirtmek istemiyoruz 
            bu yüzden code refactoring yapacağız. eski kod:  IProductService productService = new ProductManager(new EfProductDal()); */
            //Swagger -- API Documentation

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /* Get, kullanıcının api'dan istediği datadır. Post ise kullanıcının api'ya yolladığı bir datadır. 
        örn instagram'a post attım diyoruz oradaki post bizim yolladığımız bir datadır. */

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);     //ürün eklemek için: postman>post>body>raw>json formatında ekle.
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
