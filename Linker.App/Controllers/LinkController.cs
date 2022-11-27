
using System;
using System.Threading.Tasks;
using Linker.BusinessLogic.Dto;
using Linker.BusinessLogic.Service;
using Microsoft.AspNetCore.Mvc;

namespace Linker.App.Controllers;

[Route("l")]
[ApiController]
public class LinkController : Controller
{
    private readonly ILinkService m_linkService;

    public LinkController(ILinkService linkService)
    {
        m_linkService = linkService;
    }

    [HttpGet("{url}")]
    public async Task<IActionResult> Get(string url)
    {
        var redirect = await m_linkService.GetLinkAsync(url);
        return string.IsNullOrEmpty(redirect) ? Redirect($"{Request.Scheme}://{Request.Host}") : Redirect(redirect);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Post(LinkDto link)
    {
        if (Uri.TryCreate(link.Url, UriKind.Absolute, out _))
        {
            return await m_linkService.AddLinkAsync(link.Url);
        }

        return BadRequest("Not an Url");
    }
}