using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        /* IProductDal'ı yazma nedenimiz business katmanı dataaccess'e bağlı olduğu için yarın öbürgün entityframework
        yerine başka bir şey kullanırsak o oracle'a olan bağımlılığımızı minimize etmektir. */

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)  /* örneğin bu metodun hem başarılı bir şekilde gerçekleşip gerçekleşmediğini hem de
                                             bu olayın sonucunun bize verildiğini nasıl yazarız? encapsulation ile. çünkü void
                                             tek bir metod döndürür ikinciyi döndürmez bunu önlemek içinde kapsülleme yapacağız. */
        {
            if(product.ProductName.Length < 2)
            {
                //returndan önce buraya iş kodları yazılır
                //magic strings: stringleri ayrı ayrı yazmak (Messages classı oluşturduk)
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);  /*eğer bu şekilde yazmasaydık Resul resul = new Result()   result.bir şeyler
                                                              vs. yazacaktık ama constructor ile bu parametreleri direkt yazabiliriz.
                                                              başarı dönüşümlerini constructor ile kodladık(constructor, result sekmesinde) */
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            /* aşağıdaki kodun tanımı: ben DataResult döndürüyorum çalıştığım <tip> budur, parantez içinde döndürdüğüm data, işlem
            sonucu ve bilgilendirici mesaj yer alır. */
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());  //IProductDal'daki Details'i bana ver
        }
    }
}
