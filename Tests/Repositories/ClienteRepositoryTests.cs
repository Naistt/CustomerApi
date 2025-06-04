// CustomerApi.Tests/Repositories/CustomerRepositoryTests.cs
using Microsoft.EntityFrameworkCore;
using Xunit;
using CustomerApi.Infrastructure.Repositories;
using CustomerApi.Infrastructure.Context;
using CustomerApi.Domain.Entities;
using CustomerApi.Domain.ValueObjects;

public class ClienteRepositoryTests
{
    private readonly ClienteDbContext _context;
    private readonly ClienteRepository _repository;

    public ClienteRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ClienteDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Banco In-Memory
            .Options;

        _context = new ClienteDbContext(options);
        _repository = new ClienteRepository(_context);
    }

    [Fact]
    public async Task AddAsync_ShouldAddCustomerToDatabase()
    {
        // Novo cliente
        var customer = new Cliente("Vinícius Alves", "vinicius.alves@teste.com", "123456789", new Endereco("Rua 1", "123", "São Paulo", "SP", "12345"));

        await _repository.AddAsync(customer);

        var savedCustomer = await _context.Customers.FindAsync(customer.Id);
        Assert.NotNull(savedCustomer);
        Assert.Equal("Vinícius Alves", savedCustomer.Nome);
    }

    [Fact]
    public async Task EmailExistsAsync_ShouldReturnTrueIfEmailExists()
    {
        // Novo cliente com email já existente
        var customer = new Cliente("Vinícius Alves", "vinicius.alves@teste.com", "123456789", new Endereco("Rua 2", "123", "São Paulo", "SP", "12345"));
        await _repository.AddAsync(customer);

        var emailExists = await _repository.EmailExistsAsync("vinicius.alves@teste.com");

        Assert.True(emailExists);
    }
}
