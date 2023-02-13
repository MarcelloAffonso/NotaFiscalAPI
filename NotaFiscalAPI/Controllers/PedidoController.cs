using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotaFiscalAPI.Data.DTOs;
using NotaFiscalAPI.Data;
using NotaFiscalAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace NotaFiscalAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private PedidoContext _context;
    private IMapper _mapper;

    public PedidoController(PedidoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um pedido ao banco de dados.
    /// </summary>
    /// <param name="pedidoDTO">Objeto com os campos necessários para a criação de um pedido</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaEndereco(
        [FromBody] CreatePedidoDTO pedidoDTO)
    {
        // Mapeia e faz a "transferencia" dos dados do DTO para o objeto
        Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        // Por padrão, um post deverá gravar o objeto passado e depois devolve-lo para o cliente
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = pedido.Id },
            pedidoDTO);
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
        var endereco = _context.Pedidos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoDTO = _mapper.Map<ReadPedidoDTO>(endereco);

        return Ok(enderecoDTO);
    }

    /// <summary>
    /// Emite a nota fiscal do pedido e atualiza no banco de dados.
    /// </summary>
    /// <param name="id">Identificador do pedido que deverá ser parcialmente alterado</param>
    /// <param name="pedidoPatch">JSON que contém os dados que deverão ser atualizados no pedido que possui o ID informado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o pedido tenha sido encontrado e atualizado parcialmente com a nota fiscal no banco de dados.</response>
    /// <response code="404">Caso o pedido não exista exista no banco de dados.</response>
    [HttpPatch("{id}")]
    public IActionResult EmiteNotaFiscal(int id, JsonPatchDocument<UpdatePedidoDTO> pedidoPatch)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);

        // Se o jogo procurado não existe, devolve um 404 Not Found
        if (pedido == null) return NotFound();

        var pedidoParaAtualizar = _mapper.Map<UpdatePedidoDTO>(pedido);

        pedidoPatch.ApplyTo(pedidoParaAtualizar, ModelState);

        // Se não conseguiu validar o modelo do Jogo, descarta e retorna um Validation problem (erro de validação) para o cliente
        if (!TryValidateModel(pedidoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        // usa o Auto Mapper para passar os dados do DTO para o o objeto do jogo
        _mapper.Map(pedidoParaAtualizar, pedido);
        _context.SaveChanges();

        // Em atualizações, normalmente devolve um No Content
        return NoContent();
    }
}
