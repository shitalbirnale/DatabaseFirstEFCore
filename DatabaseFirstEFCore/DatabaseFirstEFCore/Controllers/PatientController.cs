using Asp.Versioning;
using DatabaseFirstEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstEFCore.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
