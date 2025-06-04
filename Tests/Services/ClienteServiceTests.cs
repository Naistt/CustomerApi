using Moq;
using Xunit;
using CustomerApi.Application.Services;
using CustomerApi.Domain.Entities;
using CustomerApi.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;
using CustomerApi.Application.DTO;
using AutoMapper;
using CustomerApi;

public class ClienteServiceTests
{
    private readonly Mock<IClienteRepository> _mockClienteRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ClienteService> _logger = new Mock<ILogger<ClienteService>>().Object;
    private readonly ClienteService _clienteService;

    public ClienteServiceTests()
    {
        _mockClienteRepository = new Mock<IClienteRepository>();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
        _mapper = new Mapper(config);
        _clienteService = new ClienteService(_mockClienteRepository.Object, _mapper, _logger);
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateCustomerSuccessfully()
    {
        // Novo cliente
        var customerDto = new ClienteDTO
        {
            Nome = "Vinícius Alves",
            Email = "vinicius.alves@teste.com",
            Telefone = "123456789",
            Endereco = new EnderecoDTO
            {
                Rua = "Rua 1",
                Numero = "123",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "12345"
            }
        };

        _mockClienteRepository
            .Setup(r => r.EmailExistsAsync(It.IsAny<string>(), It.IsAny<Guid?>()))
            .ReturnsAsync(false);  // Email não existe

        var result = await _clienteService.CreateAsync(customerDto);

        Assert.NotNull(result);
        Assert.Equal("Vinícius Alves", result.Nome);
        _mockClienteRepository.Verify(r => r.AddAsync(It.IsAny<Cliente>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowExceptionWhenEmailExists()
    {
        // Novo cliente com email já existente
        var customerDto = new ClienteDTO
        {
            Nome = "Pedro Paulo",
            Email = "vinicius.alves@teste.com",  // Mesmo email usado no teste anterior
            Telefone = "987654321",
            Endereco = new EnderecoDTO
            {
                Rua = "Rua 2",
                Numero = "456",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "54321"
            }
        };

        _mockClienteRepository
            .Setup(r => r.EmailExistsAsync(It.IsAny<string>(), It.IsAny<Guid?>()))
            .ReturnsAsync(true);  // Email já existe

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _clienteService.CreateAsync(customerDto));
        Assert.Equal("Email já cadastrado.", exception.Message);
    }
}
