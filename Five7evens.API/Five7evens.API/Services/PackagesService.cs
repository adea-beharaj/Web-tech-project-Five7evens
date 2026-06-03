using Five7evens.API.Data;
using Five7evens.API.Models;

namespace Five7evens.API.Services;

public class PackagesService
{
    private readonly AppDbContext _context;

    public PackagesService(AppDbContext context)
    {
        _context = context;
    }

    public List<Package> GetAllPackages()
    {
        return _context.Packages.ToList();
    }

    public Package? GetPackageByValue(string value)
    {
        return _context.Packages.FirstOrDefault(p => p.Value == value.ToLower());
    }

    public Package? GetPackageById(int id)
    {
        return _context.Packages.FirstOrDefault(p => p.Id == id);
    }
}
