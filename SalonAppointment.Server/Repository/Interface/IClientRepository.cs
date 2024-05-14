using SalonAppointment.Server.Models;

namespace SalonAppointment.Server.Repository.Interface
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> FindAllAsync();
        Task<Client> FindByIdAsync(Guid id);
        Task<Client> Create(Client client);
        Task<Client> Update(Guid id, Client client);
        Task<Client> Delete(Client client);
    }
}
