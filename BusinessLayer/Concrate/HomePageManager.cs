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
    public class HomePageManager : IHomePageService
    {
        IHomePageDal _homePageDal;

        public HomePageManager(IHomePageDal homePageDal)
        {
            _homePageDal = homePageDal;
        }

        public List<HomePage> GetList()
        {
            return _homePageDal.GetListAll();
        }

        public void TAdd(HomePage t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(HomePage t)
        {
            throw new NotImplementedException();
        }

        public HomePage TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(HomePage t)
        {
            throw new NotImplementedException();
        }
    }
}
