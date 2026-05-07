using Microsoft.AspNetCore.Mvc;
using MeuPrimeiroApp.Models;

namespace MeuPrimeiroApp.Controllers;

[ApiController]
[Route("api/[controller]")] public class JogosController : ControllerBase
{
    
    private static List<Jogo> _jogos = new List<Jogo>
    {
        new Jogo { Id = 1, Nome = "Elden Ring", Genero = "RPG" },
        new Jogo { Id = 2, Nome = "Tetris", Genero = "Puzzle" }
    };

    [HttpGet] 
    public ActionResult<List<Jogo>> GetTodos()
    {
        return Ok(_jogos);
    }

    [HttpPost] 
    public ActionResult Post(Jogo novoJogo)
    {
        _jogos.Add(novoJogo);
        return CreatedAtAction(nameof(GetTodos), new { id = novoJogo.Id }, novoJogo);
    }

    [HttpDelete("{id}")] 
public ActionResult Delete(int id)
{
    
    var jogo = _jogos.FirstOrDefault(j => j.Id == id);

    
    if (jogo == null)
    {
        return NotFound("Jogo não encontrado para deletar.");
    }

    
    _jogos.Remove(jogo);

   
    return NoContent();
}
}