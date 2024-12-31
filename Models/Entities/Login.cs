using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HODPoc.Models.Entities
{
    public class Login
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
