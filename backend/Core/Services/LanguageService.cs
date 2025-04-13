using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public class LanguageService
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageService(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<Language> GetLanguageById(int id)
    {
        var language = await _languageRepository.GetByIdAsync(id);

        if (language is null)
            throw new KeyNotFoundException("Language not found");

        return language;
    }

    public async Task<IEnumerable<Language>> GeAllLanguages()
    {
        return await _languageRepository.GetAllAsync();
    }

    public void AddLanguage(Language language)
    {
        _languageRepository.Add(language);
    }

    public void AddLanguages(IEnumerable<Language> languages)
    {
        _languageRepository.AddRange(languages);
    }

    public void UpdateLanguage(Language language)
    {
        var existingLanguage = _languageRepository.GetByIdAsync(language.Id).Result;

        if (existingLanguage is null)
            throw new KeyNotFoundException("Language to update not found");

        _languageRepository.Update(language);
    }

    public void DeleteLanguage(Language language)
    {
        var existingLanguage = _languageRepository.GetByIdAsync(language.Id).Result;

        if (existingLanguage is null)
            throw new KeyNotFoundException("Language to delete not found");

        _languageRepository.Remove(language);
    }
}
