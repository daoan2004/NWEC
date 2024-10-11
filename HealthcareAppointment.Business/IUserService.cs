using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;

namespace HealthcareAppointment.Business
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
