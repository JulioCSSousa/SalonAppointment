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
            return await _context.Clients
                .AsNoTracking()
                .Take(10)
                .ToListAsync();
        }

        public async Task<Client> FindByIdAsync(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            return client;
        }
            

        public async Task<Client> Create(Client client)
        {
            await _context.AddAsync(client);
            return client;
        }

        public async Task<Client> Delete(Client client)
        {
            _context.Clients.Remove(client);
            return client;
        }     

        public async Task<Client> Update(Client client)
        {
            _context.Clients.Entry(client).State = EntityState.Modified;
            return client;
        }
    }
}
