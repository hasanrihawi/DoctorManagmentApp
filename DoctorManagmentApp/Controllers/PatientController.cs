using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IValidator<PatientDtoNoPK> validator;

        public PatientController(IPatientService patientService, IValidator<PatientDtoNoPK> validator)
        {
            this.patientService = patientService;
            this.validator = validator;
        }

        // GET: api/v1/Patient
        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = patientService.GetPatients();
            return Ok(ApiResponse.SuccessResponse(patients));
        }

        // GET: api/v1/Patient/5
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = patientService.GetPatientById(id);
            if (patient == null)
                return NotFound(ApiResponse.FailResponse());

            return Ok(ApiResponse.SuccessResponse(patient));
        }

        // POST: api/v1/Patient
        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientDtoNoPK patient)
        {
            var result = await validator.ValidateAsync(patient);
            if (!result.IsValid)
                return BadRequest(ApiResponse.FailResponse(result.Errors.Select(x => x.ErrorMessage).ToList()));
            
            var createdPatient = patientService.CreatePatient(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, ApiResponse.SuccessResponse(createdPatient));
        }

        // PUT: api/v1/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDtoNoPK updatedPatient)
        {
            var result = await validator.ValidateAsync(updatedPatient);
            if (!result.IsValid)
                return BadRequest(ApiResponse.FailResponse(result.Errors.Select(x => x.ErrorMessage).ToList()));

            patientService.UpdatePatient(id, updatedPatient);
            return NoContent();
        }

        // DELETE: api/v1/Patient/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
