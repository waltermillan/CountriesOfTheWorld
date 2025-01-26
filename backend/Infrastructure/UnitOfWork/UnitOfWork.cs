using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;
namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CountriesContext _context;
    private ICountryRepository _countries;
    private ILanguageRepository _languages;
    private IGovermentRepository _goverments;
    private IContinentRepository _continents;
    private IAnthemRepository _anthems;

    public UnitOfWork(CountriesContext context)
    {
        _context = context;
    }

    public ICountryRepository Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository(_context);
            }
            return _countries;
        }
    }

    public ILanguageRepository Languages
    {
        get
        {
            if (_languages == null)
            {
                _languages = new LanguageRepository(_context);
            }
            return _languages;
        }
    }

    public IContinentRepository Continents
    {
        get
        {
            if (_continents == null)
            {
                _continents = new ContinentRepository(_context);
            }
            return _continents;
        }
    }

    public IAnthemRepository Anthems
    {
        get
        {
            if (_anthems == null)
            {
                _anthems = new AnthemRepository(_context);
            }
            return _anthems;
        }
    }

    public IGovermentRepository Goverments
    {
        get
        {
            if (_goverments == null)
            {
                _goverments = new GovermentRepository(_context);
            }
            return _goverments;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
