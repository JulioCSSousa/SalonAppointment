using Microsoft.EntityFrameworkCore;
using SalonAppointment.Server.Data;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;

namespace SalonAppointment.Server.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> FindAllAsync()
        {
            return await _context.Appointments
                .Include(x => x.Client)
                .AsNoTracking()
                .Take(10)
                .ToListAsync();
        }
        public async Task<Appointment> FindByIdAsync(Guid id)
        {
            var appointment = await _context.Appointments.Include(c => c.Client).FirstOrDefaultAsync(x => x.AppointmentCode == id);
            return appointment;
        }

        public async Task<Appointment> Create(Appointment appointment)
        {

            await _context.AddAsync(appointment);
            
            return appointment;
        }
       
        public async Task<Appointment> Update(Appointment appointment)
        {
            _context.Appointments.Entry(appointment).State = EntityState.Modified;

            return appointment;
        }

        public async Task<Appointment> Delete(Appointment appointment)
        {

            _context.Appointments.Remove(appointment);
            return appointment;
        }
    }
}
