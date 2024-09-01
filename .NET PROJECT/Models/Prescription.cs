
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace MedLab.Models
    {
        public class Prescription
        {
            [Key]
            public int PrescriptionID { get; set; }

            [Required]
            [ForeignKey("Patient")]
            public int PatientID { get; set; }
            public Patient? Patient { get; set; }

            [ForeignKey("LabAssistant")]
            public int? LabAssistantID { get; set; } // Nullable if not always assigned
            public LabAssistant? LabAssistant { get; set; }

            [Required]
            [Url]
            public string FilePath { get; set; } // Removed nullable as it's required

            [Required]
            [DataType(DataType.DateTime)]
            public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

            [ForeignKey("Department")]
            public int? DepartmentID { get; set; } // Nullable if not always assigned
            public Department? Department { get; set; }
        }
    }


