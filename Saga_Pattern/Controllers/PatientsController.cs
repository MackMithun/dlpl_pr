using Microsoft.AspNetCore.Mvc;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces;

namespace Saga_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientGetData _patientGet;

        public PatientsController(IPatientGetData patientGet)
        {
            _patientGet = patientGet;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientGet.GetAllPatients();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result =
                await _patientGet.GetPatientById(id);

            return Ok(result);
        }
    }
}
