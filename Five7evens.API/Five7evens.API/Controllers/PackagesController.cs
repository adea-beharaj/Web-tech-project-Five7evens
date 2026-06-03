using Microsoft.AspNetCore.Mvc;
using Five7evens.API.Services;

namespace Five7evens.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PackagesController : ControllerBase
{
    private readonly PackagesService _packagesService;

    public PackagesController(PackagesService packagesService)
    {
        _packagesService = packagesService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllPackages()
    {
        var packages = _packagesService.GetAllPackages();
        return Ok(packages);
    }

    [HttpGet("GetByValue")]
    public IActionResult GetPackageByValue(string value)
    {
        var package = _packagesService.GetPackageByValue(value);
        if (package == null)
            return NotFound($"Package '{value}' not found.");
        return Ok(package);
    }

    [HttpGet("GetById")]
    public IActionResult GetPackageById(int id)
    {
        var package = _packagesService.GetPackageById(id);
        if (package == null)
            return NotFound($"Package with id {id} not found.");
        return Ok(package);
    }
}
