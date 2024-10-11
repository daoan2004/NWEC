using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUserService _userService;

        public PatientsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /patients
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _userService.GetAllUsersAsync(); // Lấy tất cả bệnh nhân
            return Ok(patients);
        }

        // GET /patients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
        {
            var patient = await _userService.GetUserByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        // POST /patients
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] User patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.AddUserAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // PUT /patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(string id, [FromBody] User patient)
        {
            var existingPatient = await _userService.GetUserByIdAsync(id);
            if (existingPatient == null) return NotFound();

            existingPatient.Name = patient.Name;
            existingPatient.Email = patient.Email;

            await _userService.UpdateUserAsync(existingPatient);
            return NoContent();
        }

        // DELETE /patients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var patient = await _userService.GetUserByIdAsync(id);
            if (patient == null) return NotFound();
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
