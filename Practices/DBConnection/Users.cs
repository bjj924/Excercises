using System.ComponentModel.DataAnnotations;

namespace DBConnection
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
}
