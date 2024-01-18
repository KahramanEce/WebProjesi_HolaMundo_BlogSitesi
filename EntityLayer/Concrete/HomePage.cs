using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrete
{
    public class HomePage
    {
        [Key]
        public int HomePageID { get; set; }
        public string HomePageDetails1 { get; set; }
        public string HomePageDetails2 { get; set; }
        public string HomePageImage1 { get; set; }
        public string HomePageImage2 { get; set; }
        public string HomePageMapLocation { get; set; }
        public bool HomePageStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Comment>Comments { get; set; }
    }
}
