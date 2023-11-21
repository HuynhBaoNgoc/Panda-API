using System.ComponentModel.DataAnnotations;

namespace PandaDomain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set;}
    }
}
