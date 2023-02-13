using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Data;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ClienteContext _context;
    private IMapper _mapper;

    public ClienteController(ClienteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona cliente ao banco de dados
    /// </summary>
    /// <param name="clienteDTO">Objeto com os campos necessários para a criação de um cliente</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaCliente(
        [FromBody] CreateClienteDTO clienteDTO)
    {
        // Mapeia e faz a "transferencia" dos dados do DTO para o objeto
        Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();

        // Por padrão, um post deverá gravar o objeto passado e depois devolve-lo para o cliente
        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id },
            clienteDTO);
    }

    /// <summary>
    /// Faz uma consulta no banco de dados para buscar por um cliente específico.
    /// </summary>
    /// <param name="id">Id do cliente que deverá ser recuperado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o cliente exista no banco de dados.</response>
    /// <response code="404">Caso o cliente não exista exista no banco de dados.</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaClientePorId(int id)
    {
        // Caso o jogo não seja encontrado, retorna um erro 404 (Not Found)
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();

        var clienteDTo = _mapper.Map<ReadClienteDTO>(cliente);

        return Ok(clienteDTo);
    }
}
