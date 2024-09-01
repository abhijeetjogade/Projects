using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedLab.Constants;

namespace MedLab.Models
{
    public class Billing
    {
        [Key]
        public int BillingID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int TestID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }


        [Required]
        public DateTime BillingDate { get; set; } = DateTime.UtcNow;

        [Required]
        public PaymentStatus Status { get; set; } 

        [ForeignKey("UserID")]
        public User? User { get; set; }

        [ForeignKey("TestID")]
        public Test? Test { get; set; }
    }
}
