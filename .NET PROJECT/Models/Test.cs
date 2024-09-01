using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{

   

    
        public class Test
        {
            [Key]
            public int TestID { get; set; }

            [Required]
            [StringLength(100)]
            public string? TestName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Department Id is required")]
        public int DepartmentID { get; set; }

            [ForeignKey("DepartmentID")]
            public Department? Department { get; set; }

        
        }

   
}


