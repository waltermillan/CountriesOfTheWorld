using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LanguageRepository(Data.Context context) : GenericRepository<Language>(context), ILanguageRepository
{
    public override async Task<Language> GetByIdAsync(int id)
    {
        return await _context.Languages
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Language>> GetAllAsync()
    {
        return await _context.Languages.ToListAsync();
    }
}