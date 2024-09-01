using MedLab.Constants;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string? password { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public string? role { get; set; }
    }
}
