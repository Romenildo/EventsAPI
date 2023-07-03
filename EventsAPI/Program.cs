using EventsAPI.Config;
using EventsAPI.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("EventsCS");
builder.Services.AddDbContext<EventsDbContext>(options => options.UseSqlServer(connectionString));

//criar as migrations
//dotnet ef migrations add FirstMigration -o Persistence/Migrations
//dotnet ef migrations remove

//criar os dados no banco de dados apos criar a migrations
//dotnet ef database update

//Caso usar o banco em memoria e nao no sql server
//builder.Services.AddDbContext<EventsDbContext>(options => options.UseInMemoryDatabase("EventsDB"))

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
