using SalonAppointment.Server.Models;

namespace SalonAppointment.Server.Repository.Interface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> FindAllAsync();
        Task<Appointment> FindByIdAsync(Guid id);
        Task<Appointment> Create(Appointment appointment);
        Task<Appointment> Update(Appointment appointment);
        Task<Appointment> Delete(Appointment appointment);

    }
}
