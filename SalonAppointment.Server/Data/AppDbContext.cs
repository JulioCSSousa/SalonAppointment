using Microsoft.EntityFrameworkCore;
using SalonAppointment.Server.Models;

namespace SalonAppointment.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; } 
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
    }

}
