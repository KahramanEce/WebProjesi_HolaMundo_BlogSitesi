using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class BlogAboutManager : IBlogAboutService
    {
        IBlogAboutDal _blogaboutDal;

        public BlogAboutManager(IBlogAboutDal aboutDal)
        {
            _blogaboutDal = aboutDal;
        }

        public BlogAbout TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogAbout> GetList()
        {
            return _blogaboutDal.GetListAll();
        }

        public void TAdd(BlogAbout t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(BlogAbout t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BlogAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
