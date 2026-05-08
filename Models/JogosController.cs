using Microsoft.AspNetCore.Mvc;
using MeuPrimeiroApp.Models;
using MeuPrimeiroApp.Data; 

namespace MeuPrimeiroApp.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class JogosController : ControllerBase
{
    private readonly AppDbContext _context;

    
    public JogosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet] 
    public ActionResult<List<Jogo>> GetTodos()
    {
       
        return Ok(_context.Jogos.ToList());
    }

    [HttpPost] 
    public ActionResult Post(Jogo novoJogo)
    {
        
        _context.Jogos.Add(novoJogo);
        _context.SaveChanges(); 

        return CreatedAtAction(nameof(GetTodos), new { id = novoJogo.Id }, novoJogo);
    }

    [HttpDelete("{id}")] 
    public ActionResult Delete(int id)
    {
        
        var jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);

        if (jogo == null)
        {
            return NotFound("Jogo não encontrado para deletar.");
        }

        
        _context.Jogos.Remove(jogo);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
public ActionResult Atualizar(int id, Jogo jogoAtualizado)
{
    
    var jogoBanco = _context.Jogos.FirstOrDefault(j => j.Id == id);

    if (jogoBanco == null)
    {
        return NotFound("Jogo não encontrado para atualizar.");
    }

    
    jogoBanco.Nome = jogoAtualizado.Nome;
    jogoBanco.Genero = jogoAtualizado.Genero;

    
    _context.SaveChanges();

    return NoContent(); 
}
}