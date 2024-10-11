using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly HealthcareAppointmentContext _context;

        public AppointmentRepository(HealthcareAppointmentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorId) // Thay đổi thành string
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }
    }
}
