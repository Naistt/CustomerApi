using AutoMapper;
using CustomerApi.Application.DTO;
using CustomerApi.Domain.Entities;
using CustomerApi.Domain.Interfaces;
using CustomerApi.Domain.ValueObjects;

namespace CustomerApi.Application.Services
{
    // Application/Services/CustomerService.cs
    public class ClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository repository, IMapper mapper, ILogger<ClienteService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
            => _mapper.Map<IEnumerable<ClienteDTO>>(await _repository.GetAllAsync());

        public async Task<ClienteDTO?> GetByIdAsync(Guid id)
            => _mapper.Map<ClienteDTO>(await _repository.GetByIdAsync(id));

        public async Task<ClienteDTO> CreateAsync(ClienteDTO dto)
        {
            _logger.LogInformation("Criando cliente: {Name}", dto.Nome);

            if (await _repository.EmailExistsAsync(dto.Email))
            {
                _logger.LogWarning("Email já cadastrado: {Email}", dto.Email);
                throw new InvalidOperationException("Email já cadastrado.");
            }
                
            var address = _mapper.Map<Endereco>(dto.Endereco);
            var customer = _mapper.Map<Cliente>(dto);
            await _repository.AddAsync(customer);
            _logger.LogInformation("Cliente criado com sucesso: {Name}", customer.Nome);
            return _mapper.Map<ClienteDTO>(customer);
        }

        public async Task UpdateAsync(Guid id, ClienteDTO dto)
        {
            var customer = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Cliente não encontrado.");
            if (await _repository.EmailExistsAsync(dto.Email, id))
                throw new InvalidOperationException("Email já cadastrado.");

            var address = _mapper.Map<Endereco>(dto.Endereco);
            customer.Update(dto.Nome, dto.Email, dto.Telefone, address);
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Cliente não encontrado.");
            await _repository.DeleteAsync(customer);
        }
    }

}
