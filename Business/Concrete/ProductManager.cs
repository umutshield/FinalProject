using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Manager, iş kodlarının yazıldığı yerdir
    public class ProductManager : IProductService
    {
        //IProductDal'ı yazma nedenimiz business katmanı dataaccess'e bağlı olduğu için yarın öbürgün entityframework
        //yerine başka bir şey kullanırsak o oracle'a olan bağımlılığımızı minimize etmektir.

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları yazılır
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();    //IProductDal'daki Details'i bana ver
        }
    }
}
