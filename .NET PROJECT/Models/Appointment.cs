using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Patient Id is required")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public User? Patient { get; set; }

        [Required(ErrorMessage = "Test Id is required")]
        [ForeignKey("Test")]
        public int? TestId { get; set; }

        public Test? Test { get; set; }
    }
}