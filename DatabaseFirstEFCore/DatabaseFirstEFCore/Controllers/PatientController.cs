using Asp.Versioning;
using DatabaseFirstEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstEFCore.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetPatientDetails")]
        public async Task<IActionResult> GetPatientDetails() 
        {
            var response = await _patientService.GetPatientDetails();
            return Ok(response);
        }
    }
}
