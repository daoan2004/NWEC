using System.Threading.Tasks;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;

namespace HealthcareAppointment.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
