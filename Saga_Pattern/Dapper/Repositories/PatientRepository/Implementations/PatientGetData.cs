using Dapper;
using Npgsql;
using Saga_Pattern.Dapper.Models.PatientModel;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces;
using Saga_Pattern.Queries;

namespace Saga_Pattern.Dapper.Repositories.PatientRepository.Implementations
{
    public class PatientGetData : IPatientGetData
    {
        private readonly NpgsqlConnection _connection;
        public PatientGetData(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _connection.QueryAsync<Patient>(PatientQueries.GetAllPatients);
        }
        public async Task<Patient> GetPatientById(int id)
        {

            #pragma warning disable CS8603 // Possible null reference return.
            return await _connection.QueryFirstOrDefaultAsync<Patient>(
                PatientQueries.GetPatientById,
                new
                {
                    Patient_Id = id
                });
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
