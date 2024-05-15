using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonAppointment.Server.Models
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(12)]
        public string Phone { get; set; } = string.Empty;
        
    }
}
