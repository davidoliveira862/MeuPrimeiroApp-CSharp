using Microsoft.EntityFrameworkCore;
using MeuPrimeiroApp.Models;

namespace MeuPrimeiroApp.Data; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Jogo> Jogos { get; set; }
}