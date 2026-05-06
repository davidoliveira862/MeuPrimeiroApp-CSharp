using MeuPrimeiroApp.Models; // Adicione isso se não tiver

var builder = WebApplication.CreateBuilder(args);

// 1. Adicione suporte aos Controllers e ao Swagger
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Configure o Swagger para aparecer sempre (facilita o teste inicial)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 3. Mapeia os Controllers que criamos na pasta Controllers
app.MapControllers();

app.Run();