using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstAPP.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
}
