using BackEnd.Services;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/countries")]
public class CountryController: BaseController<Country>
{
    public CountryController(ILogger<CountryController> logger, AppDbContext context)
        : base(logger, new CountryServices(context))
    {
    }

    [HttpGet(Name = "GetAllCountries")]
    public new async Task<ActionResult<List<Country>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetCountryWithId")]
    public new async Task<ActionResult<Country>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostCountry")]
    public new async Task<ActionResult<Country>> Post([FromBody] Country country)
    {
        return await base.Post(country);
    }

    [HttpDelete("{id}", Name = "DeleteCountry")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}