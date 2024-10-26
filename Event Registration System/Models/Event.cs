using System.ComponentModel.DataAnnotations;

namespace Event_Registration_System.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }

}
