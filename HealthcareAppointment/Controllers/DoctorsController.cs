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
    public class DoctorsController : ControllerBase
    {
        private readonly IUserService _userService;

        public DoctorsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /doctors
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _userService.GetAllUsersAsync();
            return Ok(doctors);
        }

        // GET /doctors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(string id)
        {
            var doctor = await _userService.GetUserByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        // POST /doctors
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] User doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.AddUserAsync(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // PUT /doctors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(string id, [FromBody] User doctor)
        {
            var existingDoctor = await _userService.GetUserByIdAsync(id);
            if (existingDoctor == null) return NotFound();

            existingDoctor.Name = doctor.Name;
            existingDoctor.Email = doctor.Email;

            await _userService.UpdateUserAsync(existingDoctor);
            return NoContent();
        }

        // DELETE /doctors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await _userService.GetUserByIdAsync(id);
            if (doctor == null) return NotFound();
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
