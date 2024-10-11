using HealthcareAppointment.Data;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(string id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(string id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

        public async Task CancelAppointmentAsync(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                appointment.Status = "Cancelled";
                await _appointmentRepository.UpdateAsync(appointment);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorId)
        {
            return await _appointmentRepository.GetAppointmentsForDoctorAsync(doctorId);
        }
    }
}
