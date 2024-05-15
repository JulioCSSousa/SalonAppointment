using Microsoft.AspNetCore.Http.HttpResults;
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
            var service = _context.Services.FirstOrDefault(x => x.Id == id) ;
            return service;
        }

        public async Task<Service> Create(Service service)
        {
            await _context.Services.AddAsync(service);
            return service;
        }

        public async Task<Service> Delete(Service service)
        {
            _context.Services.Remove(service);
            return service;
        }


        public async Task<Service> Update(Service service)
        {
            _context.Services.Entry(service).State = EntityState.Modified;
            return service;
        }
    }
}
