using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AnthemRepository(CountriesContext context) : GenericRepository<Anthem>(context), IAnthemRepository
{
    public override async Task<Anthem> GetByIdAsync(int id)
    {
        return await _context.Anthems
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Anthem>> GetAllAsync()
    {
        return await _context.Anthems.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Anthem> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Anthems as IQueryable<Anthem>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Motto.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}