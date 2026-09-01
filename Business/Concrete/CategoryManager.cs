using Business.Abstract;
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
        ICategoryDal _categoryDal;

        /* _categoryDal'ı constructor injection yaptık ve alttaki kod oluştu.
        alttaki kod için bu şu demek: ben CategoryManager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlıyım 
        çünkü ben interface/referance üzerinden bağımlıyım bu yüzden sen DataAccess'te istediğin işlemi yap ama kurallarıma uy. 
        yani özetle diyorki ben entityframework ya da başka bir şeye bağımlı değilim. */
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        //Select * from Categories where CategoryId = 3
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId);   //buradaki c(istersen x yaz) veritabanına sorar:
                                                                      //CategoryId ile categoryId birbirine eşit mi eşitse yazdır
        }
    }
}