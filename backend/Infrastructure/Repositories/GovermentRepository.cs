using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GovermentRepository(Data.Context context) : GenericRepository<Goverment>(context), IGovermentRepository
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
}