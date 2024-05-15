using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonAppointment.Server.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do serviço requerido")]
        [StringLength(50)]
        public string ServiceName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

    }
}
