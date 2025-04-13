using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class ContinentService
    {
        private readonly IContinentRepository _continentRepository;

        public ContinentService(IContinentRepository continentRepository)
        {
            _continentRepository = continentRepository;
        }

        public async Task<Continent> GetContinentById(int id)
        {
            var continent = await _continentRepository.GetByIdAsync(id);

            if (continent is null)
                throw new KeyNotFoundException("Continent not found");

            return continent;
        }

        public async Task<IEnumerable<Continent>> GetAllContinents()
        { 
            return await _continentRepository.GetAllAsync();
        }

        public void AddContinent(Continent continent)
        {
            _continentRepository.Add(continent);
        }

        public void AddContinentRange(IEnumerable<Continent> continents)
        {
            _continentRepository.AddRange(continents);
        }

        public void UpdateContinent(Continent continent)
        {
            var existingContinent = _continentRepository.GetByIdAsync(continent.Id).Result;

            if (existingContinent is null)
                throw new KeyNotFoundException("Continent to update not found");

            _continentRepository.Update(continent);
        }

        public void DeleteContinent(Continent continent)
        {
            var existingContinent = _continentRepository.GetByIdAsync(continent.Id).Result;

            if (existingContinent is null)
                throw new KeyNotFoundException("Continent to delete not found");

            _continentRepository.Remove(continent);
        }
    }
}
