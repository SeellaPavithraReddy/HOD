using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HODPoc.Models.Entities
{
    [Table(name: "Hod7")]
    public class Hod
    {
        [Key]
        public string hodId { get; set; }
        public string school { get; set; }
        public string hodName { get; set; }
        public string address { get; set; }
        public string role { get; set; }
    }
}
