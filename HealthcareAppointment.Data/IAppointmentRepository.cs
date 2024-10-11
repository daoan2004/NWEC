using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;

namespace HealthcareAppointment.Data
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorId);
    }
}
