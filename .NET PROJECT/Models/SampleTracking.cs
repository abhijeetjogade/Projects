using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class SampleTracking
    {
        [Key]
        public int SampleTrackingID { get; set; }

        [Required]
        public int AppointmentID { get; set; }
        [ForeignKey("AppointmentID")]
        public Appointment? Appointment { get; set; }

        [Required]
        [StringLength(100)]
        public string? Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StatusUpdatedDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }
    }

}
