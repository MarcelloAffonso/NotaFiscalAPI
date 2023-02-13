using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotaFiscalAPI.Data;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController: ControllerBase
{
    private EnderecoContext _context;
    private IMapper _mapper;

    public EnderecoController(EnderecoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona endereço ao banco de dados
    /// </summary>
    /// <param name="enderecoDTO">Objeto com os campos necessários para a criação de um endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaEndereco(
        [FromBody] CreateEnderecoDTO enderecoDTO)
    {
        // Mapeia e faz a "transferencia" dos dados do DTO para o objeto
        Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        // Por padrão, um post deverá gravar o objeto passado e depois devolve-lo para o cliente
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id },
            enderecoDTO);
    }

    /// <summary>
    /// Faz uma consulta no banco de dados para buscar por um endereço específico.
    /// </summary>
    /// <param name="id">Id do endereço que deverá ser recuperado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o endereço exista no banco de dados.</response>
    /// <response code="404">Caso o endereço não exista exista no banco de dados.</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id)
    {
        // Caso o jogo não seja encontrado, retorna um erro 404 (Not Found)
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

        return Ok(enderecoDTO);
    }
}
