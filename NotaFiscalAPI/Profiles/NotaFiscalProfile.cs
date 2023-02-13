using AutoMapper;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Profiles;

public class NotaFiscalProfile : Profile
{
    public NotaFiscalProfile()
    {
        CreateMap<CreateNotaFiscalDTO, NotaFiscal>();
        CreateMap<ReadNotaFiscalDTO, NotaFiscal>();
        CreateMap<NotaFiscal, ReadNotaFiscalDTO>();
    }
}