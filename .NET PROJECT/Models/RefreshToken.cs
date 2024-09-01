using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
   
        public class RefreshToken
        {

            [Key]
            public int Id { get; set; } // Primary key
            public string? Token { get; set; } // The actual refresh token
            public DateTime CreatedDate { get; set; } // When the token was created
            public DateTime ExpiryDate { get; set; } // When the token expires
            public bool IsRevoked { get; set; } // Whether the token is revoked or not

            [ForeignKey("User")]
            public int UserId { get; set; }
            public User? User { get; set; } // Navigation property
        }
    

}