using AutoMapper;
using DoctorManagmentApp.Data;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorController> _logger;
        private readonly IMapper mapper;

        public DoctorController(ApplicationDbContext context, ILogger<DoctorController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            this.mapper = mapper;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctors = _context.Doctors.Include(x => x.Appointments).Select(d => mapper.Map<DoctorDto>(d)).ToList();

            return doctors;
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // POST: api/Doctor
        [HttpPost]
        public ActionResult<Doctor> CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, Doctor updatedDoctor)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            // Update doctor properties
            doctor.Name = updatedDoctor.Name;
            doctor.Specialization = updatedDoctor.Specialization;
            doctor.Email = updatedDoctor.Email;
            doctor.Phone = updatedDoctor.Phone;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
