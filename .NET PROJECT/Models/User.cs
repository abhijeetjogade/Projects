using System.ComponentModel.DataAnnotations;
using MedLab.Constants;
using Microsoft.AspNetCore.Identity;

namespace MedLab.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public UserRole Role { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    }
}


