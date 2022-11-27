using System.Threading.Tasks;

namespace Linker.BusinessLogic.Service;

public interface ILinkService
{
    Task<string> AddLinkAsync(string link);
    Task<string> GetLinkAsync(string id);
}