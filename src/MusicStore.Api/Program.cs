using Microsoft.EntityFrameworkCore;
using MusicStore.Repositories;
using MusicStore.Persistence;
using MusicStore.Services.Interface;
using MusicStore.Services.Implementation;
using MusicStore.Services.Profiles;

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
builder.Services.AddScoped<IConcertRepository, ConcertRepository>();
builder.Services.AddScoped<IConcertService, ConcertService>();
builder.Services.AddScoped<IGenreService, GenreService>();


//Registrar AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ConcertProfile>();
    config.AddProfile<GenreProfile>();
});
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
