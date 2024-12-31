using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HODPoc.Models.Entities
{
    [Table(name: "HodStudent7")]
    public class Student
    {
        [Key]
        public string sId { get; set; }
        public int age { get; set; }
        public string sname { get; set; }
        public string add { get; set; }
        public string sclass { get; set; }
    }
}
