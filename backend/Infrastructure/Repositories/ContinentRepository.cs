using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ContinentRepository(Data.Context context) : GenericRepository<Continent>(context), IContinentRepository
{
    public override async Task<Continent> GetByIdAsync(int id)
    {
        return await _context.Continents
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Continent>> GetAllAsync()
    {
        return await _context.Continents.ToListAsync();
    }
}