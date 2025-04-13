using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AnthemRepository(Data.Context context) : GenericRepository<Anthem>(context), IAnthemRepository
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
}