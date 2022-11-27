using Linker.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Linker.BusinessLogic.Service;

public class LinkService : ILinkService
{
    private readonly DbContext m_context;
    private const string ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int SHORTEN_LENGTH = 7;

    public LinkService(DbContext context)
    {
        m_context = context;
    }

    public async Task<string> AddLinkAsync(string link)
    {
        var id = await GetIdAsync();
        while (await m_context.Set<Link>().AnyAsync(x => x.Id == id))
        {
            id = await GetIdAsync();
        }

        await m_context.AddAsync(new Link
        {
            Id = id,
            Redirect = link
        });
        await m_context.SaveChangesAsync();
        return id;
    }

    private async Task<string> GetIdAsync()
    {
        return await Nanoid.Nanoid.GenerateAsync(ALPHABET, SHORTEN_LENGTH);
    }

    public async Task<string> GetLinkAsync(string id)
    {
        var link = await m_context.Set<Link>().FirstOrDefaultAsync(x => x.Id == id);
        return link?.Redirect ?? string.Empty;
    }

}