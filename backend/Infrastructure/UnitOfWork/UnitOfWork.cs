using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Context _context;
    private ICountryRepository _countries;
    private ILanguageRepository _languages;
    private IGovermentRepository _goverments;
    private IContinentRepository _continents;
    private IAnthemRepository _anthems;
    private ISymbolRepository _symbols;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public ICountryRepository Countries
    {
        get
        {
            if (_countries is null)
                _countries = new CountryRepository(_context);

            return _countries;
        }
    }

    public ILanguageRepository Languages
    {
        get
        {
            if (_languages is null)
                _languages = new LanguageRepository(_context);

            return _languages;
        }
    }

    public IContinentRepository Continents
    {
        get
        {
            if (_continents is null)
                _continents = new ContinentRepository(_context);

            return _continents;
        }
    }

    public IAnthemRepository Anthems
    {
        get
        {
            if (_anthems is null)
                _anthems = new AnthemRepository(_context);

            return _anthems;
        }
    }

    public IGovermentRepository Goverments
    {
        get
        {
            if (_goverments is null)
                _goverments = new GovermentRepository(_context);

            return _goverments;
        }
    }

    public ISymbolRepository Symbols
    {
        get
        {
            if (_symbols is null)
                _symbols = new SymbolRepository(_context);
            return _symbols;
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
