using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        public Blog()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }
        public int BlogID { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }
        public string Image { get; set; }
        public DateTime BlogCreateDate { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }

        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }

        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }


        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
