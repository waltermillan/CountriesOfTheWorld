using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SymbolRepository(Data.Context context) : GenericRepository<Symbol>(context), ISymbolRepository
    {
        public override async Task<Symbol> GetByIdAsync(int id)
        {
            return await _context.Symbols
                              .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Symbol>> GetAllAsync()
        {
            return await _context.Symbols.ToListAsync();
        }

    }
}
