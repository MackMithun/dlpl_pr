using Microsoft.AspNetCore.Mvc;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces;

namespace Saga_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;   
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var result = await _appointmentService.GetAllAppointment();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var result =
                await _appointmentService.GetAppointmentById(id);
            return Ok(result);
        }       

    }
}
