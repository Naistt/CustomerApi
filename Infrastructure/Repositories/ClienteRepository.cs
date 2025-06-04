using CustomerApi.Domain.Entities;
using CustomerApi.Domain.Interfaces;
using CustomerApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;

        public ClienteRepository(ClienteDbContext context) => _context = context;

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _context.Customers.ToListAsync();
        public async Task<Cliente?> GetByIdAsync(Guid id) => await _context.Customers.FindAsync(id);
        public async Task AddAsync(Cliente customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cliente customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Cliente customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, Guid? excludeId = null)
            => await _context.Customers.AnyAsync(c => c.Email == email && (!excludeId.HasValue || c.Id != excludeId.Value));
    }

}
