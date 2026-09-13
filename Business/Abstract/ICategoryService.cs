using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //Dış dünyaya yani kullanıcıya kategori ile ilgili neyi servis etmek istiyorsan o operasyonlar yazılır.
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
    }
}
