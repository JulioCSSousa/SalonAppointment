using System.ComponentModel.DataAnnotations;

namespace SalonAppointment.Server.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        public List<Service> ServicesList { get; set; } = new List<Service>();
    }
}
