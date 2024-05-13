namespace SalonAppointment.Server.Models
{
    public class Appointment
    {
        public Guid CodeId { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public List<Service> Service { get; set; } = new List<Service>();
        public DateTime DataHora { get; set; }
        public string? Observation { get; set; }
    }
}
