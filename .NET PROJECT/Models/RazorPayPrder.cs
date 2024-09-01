using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class RazorpayOrder
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int BillingID { get; set; }

        [Required]
        public string RazorpayOrderID { get; set; } // Order ID from Razorpay

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("BillingID")]
        public Billing? Billing { get; set; }
    }
}
