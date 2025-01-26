using Core.Interfases;

namespace Core.Interfases;

public interface IUnitOfWork
{
    ICountryRepository Countries { get; }
    ILanguageRepository Languages { get; }
    IGovermentRepository Goverments { get; }
    IContinentRepository Continents { get; }
    IAnthemRepository Anthems { get; }

    void Dispose();
    Task<int> SaveAsync();
}
