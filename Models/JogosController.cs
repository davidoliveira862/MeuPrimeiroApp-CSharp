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

    [HttpDelete("{id}")] // Define que a rota precisa de um ID, ex: api/jogos/1
public ActionResult Delete(int id)
{
    // 1. Procura o jogo na lista pelo ID
    var jogo = _jogos.FirstOrDefault(j => j.Id == id);

    // 2. Se não encontrar, retorna um erro 404
    if (jogo == null)
    {
        return NotFound("Jogo não encontrado para deletar.");
    }

    // 3. Se encontrar, remove da lista
    _jogos.Remove(jogo);

    // 4. Retorna 204 (No Content), que é o padrão de sucesso para deleção
    return NoContent();
}
}