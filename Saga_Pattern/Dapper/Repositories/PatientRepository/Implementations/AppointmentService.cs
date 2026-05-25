using Dapper;
using Npgsql;
using Saga_Pattern.Dapper.Models.PatientModel;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces;
using Saga_Pattern.Queries;

namespace Saga_Pattern.Dapper.Repositories.PatientRepository.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly NpgsqlConnection _connection;  
        public AppointmentService(NpgsqlConnection connection) {
            _connection= connection;        
        } 
        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            return await _connection.QueryAsync<Appointment>(AppointmentQueries.GetAllAppointment); 
        }

        public async Task<Appointment> GetAppointmentById(int _appointment_id)
        {
            #pragma warning disable CS8603 // Possible null reference return.   
            return await _connection.QueryFirstOrDefaultAsync<Appointment>(
                AppointmentQueries.GetAppointmentById,
                new
                { 
                    AppointmentId = _appointment_id
                });
            #pragma warning restore CS8603 // Possible null reference return.   
        }
    }
}
