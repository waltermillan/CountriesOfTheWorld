using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ContinentRepository(CountriesContext context) : GenericRepository<Continent>(context), IContinentRepository
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

    public override async Task<(int totalRegistros, IEnumerable<Continent> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Continents as IQueryable<Continent>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}