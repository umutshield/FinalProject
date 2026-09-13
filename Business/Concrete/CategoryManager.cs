using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        /* _categoryDal'ı constructor injection yaptık ve alttaki kod oluştu.
        alttaki kod için bu şu demek: ben CategoryManager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlıyım 
        çünkü ben interface/referance üzerinden bağımlıyım bu yüzden sen DataAccess'te istediğin işlemi yap ama kurallarıma uy. 
        yani özetle diyorki ben entityframework ya da başka bir şeye bağımlı değilim. */

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Select * from Categories where CategoryId = 3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>
                (_categoryDal.Get(c => c.CategoryId == categoryId));   //buradaki c(istersen x yaz) veritabanına sorar:
                                                                       //CategoryId ile categoryId birbirine eşit mi eşitse yazdır
        }
    }
}
