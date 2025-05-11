using Microsoft.AspNetCore.Mvc;
using DatabaseModels.Models;
using DatabaseModels.DTO;
using PatientService.Interfaces;
using Microsoft.AspNetCore.Authorization;
//using AuthService.JwtService;

namespace PatientService.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/patient")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        //private readonly JwtToken _jwtToken;
        private readonly IPatientRepository _patientRepository;
        public AdminController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        // Get all users (for testing, can be removed in production)
        [HttpPost]
        public ActionResult AddPatient(PatientDTO patient)
        {
            var patients = _patientRepository.AddPatient(patient);
            return Ok(patients);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatientData(int id)
        {
            var isDeleted = _patientRepository.DeletePatient(id);
            if (isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get a specific user

    }

}
