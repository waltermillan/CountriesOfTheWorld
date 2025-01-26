using Core.Entities;
using Core.Interfases;
using System.Collections.Generic;
using System.Numerics;

namespace Core.Services;

public class CountryService
{
    private readonly ICountryRepository _countryRepository;
    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> GetCountryById(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        if (country == null)
        {
            throw new KeyNotFoundException("Country not found");
        }
        return country;
    }

    public async Task<IEnumerable<Country>> GetCountryAll()
    {
        return await _countryRepository.GetAllAsync();
    }

    public void AddCountry(Country country) 
    { 
        _countryRepository.Add(country);
    }

    public void AddCountryRange(IEnumerable<Country> countries)
    {
        _countryRepository.AddRange(countries);
    }

    public void UpdateCountry(Country country)
    {
        var existingCountry = _countryRepository.GetByIdAsync(country.Id).Result;
        if (existingCountry == null)
        {
            throw new KeyNotFoundException("Country to update not found");
        }
        _countryRepository.Update(country);
    }

    public void DeleteCountry(Country country)
    {
        var existingCountry = _countryRepository.GetByIdAsync(country.Id).Result;
        if (existingCountry == null)
        {
            throw new KeyNotFoundException("Country to delete not found");
        }
        _countryRepository.Remove(country);
    }
}
