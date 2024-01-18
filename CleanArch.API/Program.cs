using System.Configuration;
using CleanArch.Application;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);


//register config
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add database service 
builder.Services.AddDbContext<MovieDbContext>(
    op=>op.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
    b=>b.MigrationsAssembly("CleanArch.API"))); //typeof(MovieDbContext).Assembly.GetName().Name <- infrastrue location

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MovieService).Assembly));
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