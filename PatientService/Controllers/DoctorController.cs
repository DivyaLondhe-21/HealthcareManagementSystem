using Microsoft.AspNetCore.Mvc;
using DatabaseModels.Models;
using DatabaseModels.DTO;
using PatientService.Interfaces;
using Microsoft.AspNetCore.Authorization;
//using AuthService.JwtService;

namespace PatientService.Controllers
{
    [Authorize(Roles = "Doctor,Admin")]
    [Route("api/patient")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        //private readonly JwtToken _jwtToken;
        private readonly IPatientRepository _patientRepository;
        public DoctorController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        
        // Get all users (for testing, can be removed in production)
        // Update user info
        [HttpPut("update/{id}")]
        public IActionResult UpdatePatientData(int id, PatientDTO updatePatient)
        {
            var patient = _patientRepository.UpdatePatient(id, updatePatient);
            if (patient == null)
            {
                return NotFound();
            }
           
            return NoContent();
        }

        [HttpPut("interaction/update/{id}")]
        public IActionResult UpdatePatientInteractions(int id, string interactions)
        {
            var patient = _patientRepository.UpdatePatientInteractions(id, interactions);
            if (patient == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    
    }

    // Simple Login Request Model

}
