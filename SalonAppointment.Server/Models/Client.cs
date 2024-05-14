using System.ComponentModel.DataAnnotations;

namespace SalonAppointment.Server.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(12)]
        public string Phone { get; set; } = string.Empty;
        public Guid AppointmentId { get; set; }
    }
}
