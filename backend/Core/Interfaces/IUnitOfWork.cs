namespace Core.Interfaces;

public interface IUnitOfWork
{
    ICountryRepository Countries { get; }
    ILanguageRepository Languages { get; }
    IGovermentRepository Goverments { get; }
    IContinentRepository Continents { get; }
    IAnthemRepository Anthems { get; }
    ISymbolRepository Symbols { get; }

    void Dispose();
    Task<int> SaveAsync();
}
