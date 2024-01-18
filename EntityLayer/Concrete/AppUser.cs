using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public AppUser()
        {
            Blogs = new List<Blog>();
            Likes = new List<Like>();
            //UserFollwedCats = new List<UserFollwedCat>();
            Comments = new List<Comment>();
        }
        public string NameSurname { get; set; }
        
        public string UserAbout { get; set; }
        public string UserImage { get; set; }
        //public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<Notification> Notifications { get; set; }
        //public List<UserFollwedCat> UserFollwedCats { get; set; }

        public virtual ICollection<Message> UserSender { get; set; }
        public virtual ICollection<Message> UserReceiver { get; set; }
    }
}
