using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Application.DTO
{
    public class EnderecoDTO
    {
        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string Rua { get; set; } = string.Empty;
        [Required(ErrorMessage = "O número é obrigatório.")]
        public string Numero { get; set; } = string.Empty;
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "O estado é obrigatório.")]
        public string Estado { get; set; } = string.Empty;
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string CEP { get; set; } = string.Empty;
    }
}
