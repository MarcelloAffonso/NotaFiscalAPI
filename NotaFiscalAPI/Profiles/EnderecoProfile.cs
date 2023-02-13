using AutoMapper;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Profiles;

public class EnderecoProfile: Profile
{
	public EnderecoProfile()
	{
		CreateMap<CreateEnderecoDTO, Endereco>();
		CreateMap<ReadEnderecoDTO, Endereco>();
		CreateMap<Endereco, ReadEnderecoDTO>();
	} 
}
