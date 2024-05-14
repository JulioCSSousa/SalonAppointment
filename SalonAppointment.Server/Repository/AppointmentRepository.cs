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
            return await _context.Appointments.AsNoTracking().ToListAsync();
        }
        public async Task<Appointment> FindByIdAsync(Guid id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.CodeId == id);
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            return appointment;
        }

        public async Task<Appointment> Create(Appointment appointment)
        { 
            await _context.AddAsync(appointment);
            return appointment;
        }
       
        public async Task<Appointment> Update(Guid id, Appointment appointment)
        {
            var appointmentdb = await _context.Appointments.FirstOrDefaultAsync(x => x.CodeId == id);
            if(appointment == null)
            {
                throw new NullReferenceException(nameof(appointmentdb));
            }
            _context.Appointments.Entry(appointment);
            return appointment;
        }

        public async Task<Appointment> Delete(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new NullReferenceException(nameof(appointment));
            }
            _context.Appointments.Remove(appointment);
            return appointment;
        }
    }
}
