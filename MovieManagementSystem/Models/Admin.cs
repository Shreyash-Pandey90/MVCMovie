// Admin.cs
using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.Models
{
    public class Admin
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
