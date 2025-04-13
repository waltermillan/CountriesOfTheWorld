using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Moq;

namespace Tests.UnitTests;

public class CountryServiceTests
{
    [Fact]
    public async Task GetCountryById_ReturnsCountry_WhenCountryExists()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var country = new Country { Id = 9, Name = "Country1" };
        mockCountryRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(country);

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        var result = await countryService.GetCountryById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Country1", result.Name);
        Assert.Equal(9, result.Id);
    }

    [Fact]
    public async Task GetAllCountries_ReturnsCountries_WhenCountriesExist()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var countries = new List<Country>
        {
            new Country { Id = 9, Name = "Country1" },
            new Country { Id = 13, Name = "Country2" }
        };
        mockCountryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(countries);

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        var result = await countryService.GetCountryAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); 
        Assert.Contains(result, p => p.Name == "Country1");
        Assert.Contains(result, p => p.Name == "Country2");
    }

    [Fact]
    public void AddCountry_AddsCountry_WhenCountryIsValid()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var country = new Country { Id = 9, Name = "Country1" };

        mockCountryRepository.Setup(repo => repo.Add(It.IsAny<Country>()));

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        countryService.AddCountry(country);

        // Assert
        mockCountryRepository.Verify(repo => repo.Add(It.Is<Country>(c => c.Name == "Country1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void AddRange_AddsMultipleCountries_WhenCountriesAreValid()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var countries = new List<Country>
    {
        new Country { Id = 9, Name = "Country1" },
        new Country { Id = 13, Name = "Country2" }
    };

        mockCountryRepository.Setup(repo => repo.AddRange(It.IsAny<IEnumerable<Country>>()));

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        countryService.AddCountryRange(countries);

        // Assert
        mockCountryRepository.Verify(repo => repo.AddRange(It.Is<IEnumerable<Country>>(c => c.Count() == 2 && c.Any(x => x.Name == "Country1") && c.Any(x => x.Name == "Country2"))), Times.Once);
    }

    [Fact]
    public void UpdateCountry_UpdatesCountry_WhenCountryIsValid()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var country = new Country { Id = 9, Name = "NewCountry1" };

        mockCountryRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Country { Id = 9, Name = "NewCountry1" }); 

        mockCountryRepository.Setup(repo => repo.Add(It.IsAny<Country>()));

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        countryService.UpdateCountry(country);

        // Assert
        mockCountryRepository.Verify(repo => repo.Update(It.Is<Country>(c => c.Name == "NewCountry1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void DeleteCountry_DeletesCountry_WhenCountryExists()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var country = new Country { Id = 9, Name = "NewCountry1" };

        mockCountryRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Country { Id = 9, Name = "NewCountry1" }); 

        mockCountryRepository.Setup(repo => repo.Remove(It.IsAny<Country>()));

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act
        countryService.DeleteCountry(country);

        // Assert
        mockCountryRepository.Verify(repo => repo.Remove(It.Is<Country>(c => c.Name == "NewCountry1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void UpdateCountry_ThrowsException_WhenCountryToUpdateDoesNotExist()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var country = new Country { Id = 999, Name = "NonExistingCountry" };

        mockCountryRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Country { Id = 999, Name = "NonExistingCountry" }); 

        mockCountryRepository.Setup(repo => repo.GetByIdAsync(country.Id)).ReturnsAsync((Country)null);

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => countryService.UpdateCountry(country));
        Assert.Equal("Country to update not found", exception.Message);
    }

    [Fact]
    public async Task GetCountryById_ThrowsException_WhenCountryDoesNotExist()
    {
        // Arrange
        var mockCountryRepository = new Mock<ICountryRepository>();
        var countryId = 999;

        mockCountryRepository.Setup(repo => repo.GetByIdAsync(countryId)).ReturnsAsync((Country)null);

        var countryService = new CountryService(mockCountryRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => countryService.GetCountryById(countryId));

        Assert.Equal("Country not found", exception.Message);
    }

}
