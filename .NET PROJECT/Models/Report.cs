
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public int AppointmentID { get; set; }

        [ForeignKey("AppointmentID")]
        public Appointment? Appointment { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string? FilePath { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string? UploadedBy { get; set; }

        [Required]
        public int LabAssistantID { get; set; }

        [ForeignKey("LabAssistantID")]
        public LabAssistant? LabAssistant { get; set; }
    }
}
