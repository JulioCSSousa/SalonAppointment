using Microsoft.EntityFrameworkCore;
using SalonAppointment.Server.Data;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;

namespace SalonAppointment.Server.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Client>> FindAllAsync()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> FindByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> Create(Client client)
        {
            await _context.AddAsync(client);
            return client;
        }

        public async Task<Client> Delete(Client client)
        {

            if (client == null)
            {
                throw new NullReferenceException();
            }
            _context.Clients.Remove(client);
            return client;
        }     

        public async Task<Client> Update(Guid id, Client client)
        {
            var clientdb = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (clientdb == null)
            {
                throw new InvalidOperationException();
            }
            _context.Clients.Entry(client);
            return client;
        }
    }
}
