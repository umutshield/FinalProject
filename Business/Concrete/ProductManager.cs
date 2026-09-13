using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;    //product dışında başka bir entity'nin dal'ı buraya enjekte edilemez ama service'i enjekte edilebilir

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(ProductValidator))]    //kodun tanımı: Add metodunu doğrula ProductValidator'daki kurallara göre
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)  /* örneğin bu metodun hem başarılı bir şekilde gerçekleşip gerçekleşmediğini hem de
                                             bu olayın sonucunun bize verildiğini nasıl yazarız? encapsulation ile. çünkü void
                                             tek bir metod döndürür ikinciyi döndürmez bunu önlemek içinde kapsülleme yapacağız. */
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
                CheckIfCategoryLimitExceded());

            if (result != null)    //result, kurala uymayan bir durum varsa return result döndür
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);  /* eğer bu şekilde yazmasaydık Result result = new Result()   result.bir şeyler
                                                              vs. yazacaktık ama constructor ile bu parametreleri direkt yazabiliriz.
                                                              başarı dönüşümlerini constructor ile kodladık(constructor, result sekmesinde) */
             
        }


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }


        [CacheAspect]       
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
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

        [CacheAspect]
        [PerformanceAspect(5)]      
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
        

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()     //eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün ekleme.
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
