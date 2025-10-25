using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_Ascii.Context;
using Projeto_Ascii.Dtos;
using Projeto_Ascii.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Projeto_Ascii.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : Controller
{
    private readonly IMapper _mapper;
    private readonly AsciiDbContext _context;

    public ProdutoController(IMapper mapper, AsciiDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adds a new product to the inventory.")]
    [ProducesResponseType(typeof(LerProdutoDto), StatusCodes.Status201Created)]
    public IActionResult AdicionarProduto([FromBody] CriarProdutoDto produtoDto)
    {
        Produto produto =  _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetornaProdutoPorId),
            new { id = produto.Id }, produto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(LerProdutoDto) ,StatusCodes.Status200OK)]
    public IEnumerable<LerProdutoDto> Produtos()
    {
        return _mapper.Map<IEnumerable<LerProdutoDto>>(_context.Produtos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RetornaProdutoPorId(Guid id)
    {
        var produto = _context.Produtos;
        var produtoAchado = produto.FirstOrDefault(produto => produto.Id == id);
        
        if (produtoAchado == null) return NotFound();
        return Ok(produtoAchado);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizarProduto(Guid id, [FromBody] CriarProdutoDto produtoDto)
    {
        var produto = _context.Produtos;
        var produtoAchado = produto.FirstOrDefault(produto => produto.Id == id);
        
        if (produtoAchado == null) return NotFound();
        _mapper.Map(produtoDto, produtoAchado);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void),StatusCodes.Status404NotFound)]
    public IActionResult DeletarProduto(Guid id)
    {
        var produto = _context.Produtos;
        var produtoAchado = produto.FirstOrDefault(produto => produto.Id == id);
        
        if (produtoAchado == null) return NotFound();
        _context.Remove(produtoAchado);
        _context.SaveChanges();
        return NoContent();
    }
}