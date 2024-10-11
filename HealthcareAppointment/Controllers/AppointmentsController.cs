using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET /appointments
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        // GET /appointments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(string id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        // POST /appointments
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _appointmentService.AddAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // PUT /appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromBody] Appointment appointment)
        {
            var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (existingAppointment == null) return NotFound();

            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.Date = appointment.Date;
            existingAppointment.Status = appointment.Status;

            await _appointmentService.UpdateAppointmentAsync(existingAppointment);
            return NoContent();
        }

        // DELETE /appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }

        // PATCH /appointments/{id}/cancel
        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelAppointment(string id)
        {
            await _appointmentService.CancelAppointmentAsync(id);
            return NoContent();
        }
            
        // GET /doctors/{doctorId}/search
        [HttpGet("doctors/{doctorId}/search")]
        public async Task<IActionResult> GetAppointmentsForDoctor(string doctorId, int? pageNumber = null, int? pageSize = null)
        {
            var appointments = await _appointmentService.GetAppointmentsForDoctorAsync(doctorId);

            // Optional: Filtering, Sorting, and Pagination Logic Here

            return Ok(appointments);
        }
    }
}
