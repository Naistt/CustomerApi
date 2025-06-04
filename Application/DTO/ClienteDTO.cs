using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Application.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public EnderecoDTO Endereco { get; set; } = default!;
    }

}
