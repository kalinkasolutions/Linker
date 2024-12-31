using System.Threading.Tasks;
using Linker.BusinessLogic.Entities;

namespace Linker.BusinessLogic.Service;

public interface ILinkService
{
    Task<string> AddLinkAsync(string link);
    Task<Link> GetRedirectAsync(string id);
}