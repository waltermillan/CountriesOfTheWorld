using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LanguageRepository(CountriesContext context) : GenericRepository<Language>(context), ILanguageRepository
{

    // Método existente
    public override async Task<Language> GetByIdAsync(int id)
    {
        return await _context.Languages
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método existente
    public override async Task<IEnumerable<Language>> GetAllAsync()
    {
        return await _context.Languages.ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<Language> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Languages as IQueryable<Language>;

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