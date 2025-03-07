using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GovermentRepository(CountriesContext context) : GenericRepository<Goverment>(context), IGovermentRepository
{
    public override async Task<Goverment> GetByIdAsync(int id)
    {
        return await _context.Goverments
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Goverment>> GetAllAsync()
    {
        return await _context.Goverments.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Goverment> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Goverments as IQueryable<Goverment>;

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