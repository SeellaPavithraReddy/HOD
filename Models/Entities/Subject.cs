using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    [Table(name: "Subject7")]
    public class Subject
    {
        [Key]
        public string suId { get; set; }
        public string science { get; set; }
        public string social { get; set; }
        public string maths { get; set; }
        public string english { get; set; }
        public string telugu { get; set; }
        public string hindi { get; set; }
    }
}
