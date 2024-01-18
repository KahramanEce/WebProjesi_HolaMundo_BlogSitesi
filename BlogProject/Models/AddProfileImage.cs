namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int AppUserID { get; set; }
        public string NameSurname{ get; set; }
        public string UserAbout { get; set; }
        public IFormFile Image { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserStatus { get; set; }
    }
}
