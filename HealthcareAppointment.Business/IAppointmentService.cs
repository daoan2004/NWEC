using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;

namespace HealthcareAppointment.Business
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(string id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(string id);
        Task CancelAppointmentAsync(string id);
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorId);
    }
}
