using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticeWebApi1.Models
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        [Range(3, 255)]
        public string Name { get; set; }
        [Range(5, 255)]
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [Range(8, 255)]
        public string Password { get; set; }
        public EnumRole Role { get; set; }
        public string Specialization { get; set; } = string.Empty;
    }
}
