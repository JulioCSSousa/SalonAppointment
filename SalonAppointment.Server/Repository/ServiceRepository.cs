using Microsoft.EntityFrameworkCore;
using SalonAppointment.Server.Data;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;

namespace SalonAppointment.Server.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> FindAllAsync()
        {
            return await _context.Services.AsNoTracking().ToListAsync();
        }
        public async Task<Service> FindByIdAsync(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id) ;
        }

        public async Task<Service> Create(Service service)
        {
            await _context.Services.AddAsync(service);
            return service;
        }

        public async Task<Service> Delete(Service service)
        {
 
            if (service != null)
            {
                throw new InvalidOperationException();
            }
            _context.Services.Remove(service);
            return service;
        }


        public async Task<Service> Update(int id, Service service)
        {
            var servicedb = await _context.Services.FirstOrDefaultAsync(x => x.Id == id); 
            if (servicedb != null)
            {
                throw new NullReferenceException();
            }
            _context.Services.Entry(service);
            return service;
        }
    }
}
