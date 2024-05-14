using SalonAppointment.Server.Models;

namespace SalonAppointment.Server.Repository.Interface
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> FindAllAsync();
        Task<Service> FindByIdAsync(int id);
        Task<Service> Create(Service service);
        Task<Service> Update(int id,Service service);
        Task<Service> Delete(Service service);
    }
}
