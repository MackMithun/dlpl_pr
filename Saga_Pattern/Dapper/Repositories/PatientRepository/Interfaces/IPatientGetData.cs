using Saga_Pattern.Dapper.Models.PatientModel;

namespace Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces
{
    public interface IPatientGetData
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
    }
}
