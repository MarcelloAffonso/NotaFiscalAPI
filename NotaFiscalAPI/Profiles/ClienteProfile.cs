using AutoMapper;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDTO, Cliente>();
        CreateMap<ReadClienteDTO, Cliente>();
        CreateMap<Cliente, ReadClienteDTO>();
    }
}