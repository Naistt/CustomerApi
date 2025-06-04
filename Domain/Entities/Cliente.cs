using CustomerApi.Domain.ValueObjects;

namespace CustomerApi.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente() { }

        public Cliente(string name, string email, string phone, Endereco address)
        {
            Nome = name;
            Email = email;
            Telefone = phone;
            Endereco = address;
        }

        public void Update(string name, string email, string? phone, Endereco address)
        {
            Nome = name;
            Email = email;
            Telefone = phone;
            Endereco = address;
        }
    }

}
