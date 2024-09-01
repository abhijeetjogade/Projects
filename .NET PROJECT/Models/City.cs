using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        public string CityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "State Id is required")]
        [ForeignKey("State")]
        public int StateId { get; set; }

        public State? State { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
