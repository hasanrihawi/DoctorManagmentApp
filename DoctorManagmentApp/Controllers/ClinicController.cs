using DoctorManagmentApp.Data;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClinicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clinic
        [HttpGet]
        public ActionResult<IEnumerable<ClinicDto>> GetClinics()
        {
            var clinics = _context.Clinics.Select(c => new ClinicDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Phone = c.Phone
            }).ToList();

            return clinics;
        }

        // GET: api/Clinic/5
        [HttpGet("{id}")]
        public ActionResult<Clinic> GetClinic(int id)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        // POST: api/Clinic
        [HttpPost]
        public ActionResult<Clinic> CreateClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClinic), new { id = clinic.Id }, clinic);
        }

        // PUT: api/Clinic/5
        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, Clinic updatedClinic)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic == null)
            {
                return NotFound();
            }

            // Update clinic properties
            clinic.Name = updatedClinic.Name;
            clinic.Address = updatedClinic.Address;
            clinic.Phone = updatedClinic.Phone;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Clinic/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic == null)
            {
                return NotFound();
            }

            _context.Clinics.Remove(clinic);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
