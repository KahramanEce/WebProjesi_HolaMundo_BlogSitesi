using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetSendBoxWithMessageByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.ReceiverUser).Where(y => y.SenderID == id).ToList();
            }
        }

        public List<Message> GetInBoxWithMessageByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }

    }
}
