using MedLab.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class PaymentTransaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        public int BillingID { get; set; }

        [Required]
        public string? RazorpayPaymentID { get; set; } // Payment ID from Razorpay

        [Required]
        public string? RazorpayOrderID { get; set; } // Order ID from Razorpay

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public PaymentStatus Status { get; set; } // e.g., Success, Failed

        [ForeignKey("BillingID")]
        public Billing? Billing { get; set; }
    }
}
