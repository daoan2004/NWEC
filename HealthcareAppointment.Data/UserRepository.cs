using HealthcareAppointment.Models;
using HealthcareAppointment.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly HealthcareAppointmentContext _context;

        public UserRepository(HealthcareAppointmentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
