using System.Transactions;

namespace SalonAppointment.Server.Repository.Interface
{
    public interface IUnitOfWork
    {
        IAppointmentRepository AppointmentRepository { get; }
        IClientRepository ClientRepository { get; }
        IServiceRepository ServiceRepository { get; }
        void Commit();
    }
}
