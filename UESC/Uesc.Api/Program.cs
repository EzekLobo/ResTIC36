
using Uesc.Infra.DATA;
using Uesc.Infra.Repository;
using Uesc.Business.Services;
using Uesc.Business.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UescDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
    
builder.Services.AddScoped<IAlunoService, AlunoService>(); 
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<LogMiddleware>(); 

app.UseAuthorization(); 

app.MapControllers();

app.Run();