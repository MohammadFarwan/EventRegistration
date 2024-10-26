using System.ComponentModel.DataAnnotations;

namespace Event_Registration_System.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ParticipantName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }
    }

}
