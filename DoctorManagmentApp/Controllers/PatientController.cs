using DoctorManagmentApp.Data;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IPatientService patientService;

        public PatientController(ApplicationDbContext context, IPatientService patientService)
        {
            this.context = context;
            this.patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult<List<PatientDto>> GetPatients()
        {
            return patientService.GetPatients();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public ActionResult<PatientDto> GetPatient(int id)
        {
            var patient = patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public ActionResult<PatientDto> CreatePatient(PatientDtoCreate patient)
        {
            var createdPatient = patientService.CreatePatient(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, createdPatient);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, PatientDto updatedPatient)
        {
            var isUpdated = patientService.UpdatePatient(id, updatedPatient);

            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var isDeleted = patientService.DeletePatient(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }

}
