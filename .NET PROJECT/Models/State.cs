using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class State
    {


        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State Name is required")]
        public string? StateName { get; set; }

        public ICollection<City> Cities { get; set; } = new HashSet<City>();

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}

