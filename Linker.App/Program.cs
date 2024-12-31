using System;
using System.Net.Mime;
using Linker.BusinessLogic.Dal;
using Linker.BusinessLogic.Dto;
using Linker.BusinessLogic.Entities;
using Linker.BusinessLogic.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext, LinkerContext>();
builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
if (serviceScope != null)
{
    var context = serviceScope.ServiceProvider.GetRequiredService<LinkerContext>();
    context.Database.Migrate();
}

app.MapGet("/l/{url}", async (string url, HttpContext httpContext, ILinkService linkService) =>
{
    Link redirect = await linkService.GetRedirectAsync(url);
    if (redirect != null)
    {
        return Results.Redirect(redirect.Redirect);
    }

    return Results.Redirect($"{httpContext.Request.Scheme}://{httpContext.Request.Host}");
});

app.MapPost("/l", async (LinkDto link, ILinkService linkService) =>
{
    if (!Uri.TryCreate(link.Url, UriKind.Absolute, out _))
    {
        return Results.BadRequest("Not an Url");
    }

    return Results.Content(await linkService.AddLinkAsync(link.Url), MediaTypeNames.Text.Plain);
});

app.Run();