using AutoMapper;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Profiles;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDTO, Pedido>();
        CreateMap<ReadEnderecoDTO, Pedido>();
        CreateMap<UpdatePedidoDTO, Pedido>();
        CreateMap<Pedido, UpdatePedidoDTO>();
        CreateMap<Pedido, ReadEnderecoDTO>();
    }
}