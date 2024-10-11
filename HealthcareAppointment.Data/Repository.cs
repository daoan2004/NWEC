using HealthcareAppointment.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HealthcareAppointmentContext _context;
        private readonly DbSet<T> _entities;

        public Repository(HealthcareAppointmentContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<T> GetByIdAsync(string id) => await _entities.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
