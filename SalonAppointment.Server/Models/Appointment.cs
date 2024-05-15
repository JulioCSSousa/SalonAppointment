using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace SalonAppointment.Server.Models
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentCode { get; set; } = Guid.NewGuid();
        public Client Client { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataHora { get; set; }
        [StringLength(300)]
        public string? Observation { get; set; } = string.Empty;
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
    }
}
