using Core.Entities;
using Core.Interfases;
using Core.Services;
using Moq;

namespace Tests.UnitTests;

public class ContinentServiceTests
{
    [Fact]
    public async Task GetContinentById_ReturnsContinent_WhenCountryExists()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "Continent1" };
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(continent);

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        var result = await continentService.GetContinentById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Continent1", result.Name);
        Assert.Equal(9, result.Id);
    }

    [Fact]
    public async Task GetAllContinents_ReturnsContinents_WhenContinentsExist()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continents = new List<Continent>
        {
            new Continent { Id = 9, Name = "Continent1" },
            new Continent { Id = 13, Name = "Continent2" }
        };
        mockContinentRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(continents);

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        var result = await continentService.GetAllContinents();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Continent1");
        Assert.Contains(result, p => p.Name == "Continent2");
    }

    [Fact]
    public void AddContinent_AddsContinent_WhenContinentIsValid()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "Continent1" };

        mockContinentRepository.Setup(repo => repo.Add(It.IsAny<Continent>()));

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        continentService.AddContinent(continent);

        // Assert
        mockContinentRepository.Verify(repo => repo.Add(It.Is<Continent>(c => c.Name == "Continent1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void AddRange_AddsMultipleContinents_WhenContinentsAreValid()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continents = new List<Continent>
            {
                new Continent { Id = 9, Name = "Continent1" },
                new Continent { Id = 13, Name = "Continent2" }
            };

        mockContinentRepository.Setup(repo => repo.AddRange(It.IsAny<IEnumerable<Continent>>()));

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        continentService.AddContinentRange(continents);

        // Assert
        mockContinentRepository.Verify(repo => repo.AddRange(It.Is<IEnumerable<Continent>>(c => c.Count() == 2 && c.Any(x => x.Name == "Continent1") && c.Any(x => x.Name == "Continent2"))), Times.Once);
    }

    /*
        1. Arrange (Prepare) => In this phase, you prepare a mock object.
        2. Mock (Simulation) => A mock is a simulated object that mimics the behavior of a real object in a unit test.
        3. Act (Execute) => In this phase, the action or method we are testing is executed. 
        4. Assert (Verify) => In this phase, we verify that the result of the executed action meets our expectations.
    */


    [Fact]
    public void UpdateContinent_UpdatesContinent_WhenContinentIsValid()
    {

        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "NewContinent1" };

        mockContinentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Continent { Id = 9, Name = "Continent1" });
        mockContinentRepository.Setup(repo => repo.Update(It.IsAny<Continent>()));
        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        continentService.UpdateContinent(continent);

        // Assert
        mockContinentRepository.Verify(repo => repo.Update(It.Is<Continent>(c => c.Name == "NewContinent1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void DeleteContinent_DeletesContinent_WhenContinentExists()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "Continent1" };

        mockContinentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Continent { Id = 9, Name = "Continent1" });
        mockContinentRepository.Setup(repo => repo.Remove(It.IsAny<Continent>()));
        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        continentService.DeleteContinent(continent);

        // Assert
        mockContinentRepository.Verify(repo => repo.Remove(It.Is<Continent>(c => c.Name == "Continent1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public async Task GetContinentById_ThrowsException_WhenContinentDoesNotExist()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continentId = 999;
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(continentId)).ReturnsAsync((Continent)null);

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => continentService.GetContinentById(continentId));
        Assert.Equal("Continent not found", exception.Message);
    }
}
