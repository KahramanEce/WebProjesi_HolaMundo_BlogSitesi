using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Like
    {
        public int LikeID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
