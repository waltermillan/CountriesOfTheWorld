using Core.Entities;
using Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services;

public class AnthemService
{
    private readonly IAnthemRepository _anthemRepository;

    public AnthemService(IAnthemRepository anthemRepository)
    {
        _anthemRepository = anthemRepository;
    }

    public async Task<Anthem> GetAnthemById(int id)
    {
        var anthem = await _anthemRepository.GetByIdAsync(id);
        if (anthem == null)
        {
            throw new KeyNotFoundException("Anthem not found");
        }
        return anthem;
    }

    public async Task<IEnumerable<Anthem>> GeAllAnthems()
    {
        return await _anthemRepository.GetAllAsync();
    }

    public void AddAnthem(Anthem anthem)
    {
        _anthemRepository.Add(anthem);
    }

    public void AddAnthems(IEnumerable<Anthem> anthem)
    {
        _anthemRepository.AddRange(anthem);
    }

    public void UpdateAnthem(Anthem anthem)
    {
        var existingAnthem = _anthemRepository.GetByIdAsync(anthem.Id).Result;
        if (existingAnthem == null)
        {
            throw new KeyNotFoundException("Anthem to update not found");
        }
        _anthemRepository.Update(anthem);
    }

    public void DeleteLanguage(Anthem anthem)
    {
        var existingAnthem = _anthemRepository.GetByIdAsync(anthem.Id).Result;
        if (existingAnthem == null)
        {
            throw new KeyNotFoundException("Anthem to delete not found");
        }
        _anthemRepository.Remove(anthem);
    }
}
