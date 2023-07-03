using EventsAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adicionar como Singleton para funcioanr como um banco de dados local de utilizando LISTS
//sem necessariamente ter um banco de dados conectado
builder.Services.AddSingleton<EventsDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
