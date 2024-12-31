using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HODPoc.Models.Entities
{
    [Table(name: "Teacher7")]
    public class Teacher
    {
        [Key]
        public string tId { get; set; }
        public int age { get; set; }
        public string tName { get; set; }
        public string classes { get; set; }
        public string role { get; set; }
    }
}
