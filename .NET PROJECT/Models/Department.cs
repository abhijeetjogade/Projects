using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; } = string.Empty;

        public ICollection<LabAssistant> LabAssistants { get; set; } = new HashSet<LabAssistant>();
        public ICollection<Test> Tests { get; set; } = new HashSet<Test>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}