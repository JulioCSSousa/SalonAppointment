using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SalonAppointment.Server.Models
{
    public class Appointment
    {
        [Key]
        public Guid CodeId { get; set; }
        public Client? Client { get; set; }
        public Guid? ClientID { get; set; }
        public DateTime DataHora { get; set; }
        [StringLength(300)]
        public string? Observation { get; set; } = string.Empty;
        public IEnumerable<Service>? ServicesList { get; set; } = new List<Service>();
    }
}
