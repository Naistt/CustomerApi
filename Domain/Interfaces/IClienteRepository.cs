using CustomerApi.Domain.Entities;

namespace CustomerApi.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(Guid id);
        Task AddAsync(Cliente customer);
        Task UpdateAsync(Cliente customer);
        Task DeleteAsync(Cliente customer);
        Task<bool> EmailExistsAsync(string email, Guid? excludeId = null);
    }

}
