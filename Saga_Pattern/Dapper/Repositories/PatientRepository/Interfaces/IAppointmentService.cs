using Npgsql;
using Saga_Pattern.Dapper.Models.PatientModel;

namespace Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointment();
        Task<Appointment> GetAppointmentById(int _appointment_id);
    }
}
