using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogAbout
    {
        [Key]
        public int BlogAboutID { get; set; }
        public string BlogAboutDetails { get; set; }
        public string BlogAboutImage { get; set; }
        public string BlogAboutMapLocation { get; set; }
        public bool BlogAboutStatus { get; set; }
    }
}
