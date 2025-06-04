using AutoMapper;
using CustomerApi.Application.DTO;
using CustomerApi.Domain.Entities;
using CustomerApi.Domain.ValueObjects;

namespace CustomerApi
{
    // API/MappingProfile.cs
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }

}
