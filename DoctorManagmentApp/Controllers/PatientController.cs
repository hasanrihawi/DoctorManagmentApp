using DoctorManagmentApp.Data;
using DoctorManagmentApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return _context.Patients.ToList();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public ActionResult<Patient> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            // Update patient properties
            patient.Name = updatedPatient.Name;
            patient.Email = updatedPatient.Email;
            patient.Phone = updatedPatient.Phone;
            patient.Address = updatedPatient.Address;
            patient.Gender = updatedPatient.Gender;
            patient.DateOfBirth = updatedPatient.DateOfBirth;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
