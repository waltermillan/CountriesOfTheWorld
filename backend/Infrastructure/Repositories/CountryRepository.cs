using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CountryRepository(Data.Context context) : GenericRepository<Country>(context), ICountryRepository
{
    public override async Task<Country> GetByIdAsync(int id)
    {
        return await _context.Countries
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries.ToListAsync();
    }
}