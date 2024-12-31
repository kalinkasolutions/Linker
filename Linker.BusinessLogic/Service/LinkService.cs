using System;
using Linker.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Linker.BusinessLogic.Service;

public class LinkService(DbContext context, IMemoryCache cache) : ILinkService
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int ShortenLength = 7;

    public async Task<string> AddLinkAsync(string link)
    {
        string id = await GetIdAsync();
        while (await context.Set<Link>().AnyAsync(x => x.Id == id))
        {
            id = await GetIdAsync();
        }

        await context.AddAsync(new Link
        {
            Id = id,
            Redirect = link
        });

        await context.SaveChangesAsync();
        return id;
    }

    private static async Task<string> GetIdAsync()
    {
        return await Nanoid.Nanoid.GenerateAsync(Alphabet, ShortenLength);
    }

    public async Task<Link> GetRedirectAsync(string id)
    {
        if (cache.TryGetValue(id, out Link cachedLink))
        {
            return cachedLink;
        }

        Link link = await context.Set<Link>().FirstOrDefaultAsync(x => x.Id == id);
        if (link != null)
        {
            return cache.Set(id, link, TimeSpan.FromDays(1));
        }

        return null;
    }
}