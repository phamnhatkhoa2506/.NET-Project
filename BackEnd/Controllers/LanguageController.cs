using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/languages")]
public class LanguageController:  BaseController<Language>
{
    public LanguageController(ILogger<LanguageController> logger, AppDbContext context)
        : base(logger, new LanguageServices(context))
    {
    }

    [HttpGet(Name = "GetAllLanguages")]
    public new async Task<ActionResult<List<Language>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetLanguageWithId")]
    public new async Task<ActionResult<Language>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostLanguage")]
    public new async Task<ActionResult<Language>> Post([FromBody] Language language)
    {
        return await base.Post(language);
    }

    [HttpDelete("{id}", Name = "DeleteLanguage")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}