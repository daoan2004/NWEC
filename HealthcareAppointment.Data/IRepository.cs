using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id); // Đổi thành string
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id); // Đổi thành string
    }
}
