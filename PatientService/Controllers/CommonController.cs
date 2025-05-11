using Microsoft.AspNetCore.Mvc;
using DatabaseModels.Models;
using DatabaseModels.DTO;
using PatientService.Interfaces;
using Microsoft.AspNetCore.Authorization;
//using AuthService.JwtService;

namespace PatientService.Controllers
{
    [Authorize(Roles ="Nurse,Doctor,Admin")]
    [Route("api/patient")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public CommonController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatient()
        {
            var patients = _patientRepository.GetPatient();
            return Ok(patients);
        }

        // Get a specific user
        [HttpGet("{id}")]
        public ActionResult<Patient> GetpatientbyId(int id)
        {
            var patient = _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("{name}")]
        public ActionResult<Patient> GetpatientbyName(string name)
        {
            var patient = _patientRepository.GetPatientByName(name);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

    }
}