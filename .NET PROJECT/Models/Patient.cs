using MedLab.Constants;
using MedLab.Models;
using System.ComponentModel.DataAnnotations;


namespace MedLab.Models
{
   

        public class Patient
        {
            [Key]
            public int PatientID { get; set; }

            [Required]
            [StringLength(100)]
            public string? Name { get; set; }

            [Required]
            [EmailAddress]
            public string? Email { get; set; }

            [Required]
            [Phone]
            public string? PhoneNumber { get; set; }

            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [StringLength(200)]
            public string? Address { get; set; }

            [StringLength(100)]
            public string? City { get; set; }

            [StringLength(100)]
            public string? State { get; set; }




            [Required]
            public Gender Gender { get; set; } // Enum for gender

            public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
            public ICollection<Billing> Billings { get; set; } = new List<Billing>();
        }
    }

