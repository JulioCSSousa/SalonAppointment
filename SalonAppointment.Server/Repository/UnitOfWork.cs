using SalonAppointment.Server.Data;
using SalonAppointment.Server.Repository.Interface;
using System.Xml.Serialization;

namespace SalonAppointment.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAppointmentRepository _appointmentRepo;

        public IClientRepository _clientRepo;

        public IServiceRepository _serviceRepo; 

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                return _appointmentRepo = _appointmentRepo ?? new AppointmentRepository(_context);
            }
        }
        public IClientRepository ClientRepository
        {
            get
            {
                return _clientRepo = _clientRepo ?? new ClientRepository(_context);
            }
        }
        public IServiceRepository ServiceRepository
        {
            get
            {
                return _serviceRepo = _serviceRepo ?? new ServiceRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
