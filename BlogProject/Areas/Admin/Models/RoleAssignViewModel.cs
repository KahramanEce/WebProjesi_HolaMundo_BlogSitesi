namespace CoreDemo.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }   //Exists:Kullanici bu rolü içeriyor mu? anlaminda kullanildi.
    }
}
