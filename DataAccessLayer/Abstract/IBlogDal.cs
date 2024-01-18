using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();  //Bloglarin kategorilerini gostermek icin olusturduk.

        List<Blog> GetListWithCategoryByUser(int id);
       

    }
}
