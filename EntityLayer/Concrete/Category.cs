using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
       
        public Category()
        {
            Blogs = new List<Blog>();
            //FollwedCats = new List<FollwedCat>();

        }
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; }
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }

        //public List<FollwedCat> FollwedCats { get; set; }
    }
}
