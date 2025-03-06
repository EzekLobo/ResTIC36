using System.IO;
using System.Text.Json;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;

public class LogMiddleware
{
    private readonly RequestDelegate _next;
    

    public LogMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context, UescDbContext dbContext)
    {
        await _next(context); 

        var log = new Log
        {
            Metodo = context.Request.Method,
            Url = context.Request.Path,
            StatusCode = context.Response.StatusCode,
            DataHora = DateTime.UtcNow
        };

       
        dbContext.Logs.Add(log);
        await dbContext.SaveChangesAsync();

        
       /* var logTexto = JsonSerializer.Serialize(log) + Environment.NewLine;
        await File.AppendAllTextAsync("logs.txt", logTexto);*/
    }
}
