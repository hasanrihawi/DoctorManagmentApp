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
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDto>> GetAppointments()
        {
            var appointments = _context.Appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientID = a.PatientID,
                DoctorID = a.DoctorID,
                ClinicID = a.ClinicID,
                AppointmentDateTime = a.AppointmentDateTime,
                ArrivalDateTime = a.ArrivalDateTime,
                CompletionDateTime = a.CompletionDateTime
            }).ToList();

            return appointments;
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // POST: api/Appointment
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, AppointmentDto updatedAppointment)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            // Update appointment properties
            appointment.PatientID = updatedAppointment.PatientID;
            appointment.DoctorID = updatedAppointment.DoctorID;
            appointment.ClinicID = updatedAppointment.ClinicID;
            appointment.AppointmentDateTime = updatedAppointment.AppointmentDateTime;
            appointment.ArrivalDateTime = updatedAppointment.ArrivalDateTime;
            appointment.CompletionDateTime = updatedAppointment.CompletionDateTime;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
