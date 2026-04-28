using Microsoft.EntityFrameworkCore;
using MusicStore.Repositories;
using MusicStore.Persistence;

#region middleware
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//agregar swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registrar el servicio de MusicStore
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

//de aquí en adelante se indican que elementos usa la app
var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
