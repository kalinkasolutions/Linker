using Linker.BusinessLogic.Dal;
using Linker.BusinessLogic.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DbContext, LinkerContext>();
builder.Services.AddTransient<ILinkService, LinkService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
if (serviceScope != null)
{
    var context = serviceScope.ServiceProvider.GetRequiredService<LinkerContext>();
    context.Database.Migrate();
}

app.Run();
