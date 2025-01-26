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
        Assert.Equal(2, result.Count()); // Usamos Count() para contar los elementos
        Assert.Contains(result, p => p.Name == "Continent1");
        Assert.Contains(result, p => p.Name == "Continent2");
    }

    [Fact]
    public void AddContinent_AddsContinent_WhenContinentIsValid()
    {
        // arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "Continent1" };

        mockContinentRepository.Setup(repo => repo.Add(It.IsAny<Continent>()));

        var continentService = new ContinentService(mockContinentRepository.Object);

        // act
        continentService.AddContinent(continent);

        // assert
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

        // Configuramos el mock para verificar que AddRange sea llamado con la lista correcta de continentes
        mockContinentRepository.Setup(repo => repo.AddRange(It.IsAny<IEnumerable<Continent>>()));

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act
        continentService.AddContinentRange(continents);

        // Assert
        mockContinentRepository.Verify(repo => repo.AddRange(It.Is<IEnumerable<Continent>>(c => c.Count() == 2 && c.Any(x => x.Name == "Continent1") && c.Any(x => x.Name == "Continent2"))), Times.Once);
    }

    [Fact]
    public void UpdateContinent_UpdatesContinent_WhenContinentIsValid()
    {
        /*
            1. Arrange (Preparar) => En esta fase, se prepar
            2. Mock (Simulación) => Un mock es un objeto simulado que imita el comportamiento de un objeto real en una prueba unitaria.
            3. Act (Ejecutar) => En esta fase, se ejecuta la acción o método que estamos probando. 
            4. Assert (Verificar) => En esta fase, verificamos que el resultado de la acción ejecutada cumpla con nuestras expectativas.
         */

        //1- arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "NewContinent1" };

        //2- Configuramos el mock para que devuelva el continente que estamos actualizando
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Continent { Id = 9, Name = "Continent1" }); // Simulamos que el continente con Id 9 existe
        mockContinentRepository.Setup(repo => repo.Update(It.IsAny<Continent>()));
        var continentService = new ContinentService(mockContinentRepository.Object);

        //3- act
        continentService.UpdateContinent(continent);

        //4- assert
        mockContinentRepository.Verify(repo => repo.Update(It.Is<Continent>(c => c.Name == "NewContinent1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void DeleteContinent_DeletesContinent_WhenContinentExists()
    {
        //1- arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 9, Name = "Continent1" };

        //2- Configuramos el mock para que devuelva el continente que estamos eliminando
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Continent { Id = 9, Name = "Continent1" }); // Simulamos que el continente con Id 9 existe
        mockContinentRepository.Setup(repo => repo.Remove(It.IsAny<Continent>()));
        var continentService = new ContinentService(mockContinentRepository.Object);

        //3- act
        continentService.DeleteContinent(continent);

        //4- assert
        mockContinentRepository.Verify(repo => repo.Remove(It.Is<Continent>(c => c.Name == "Continent1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public async Task GetContinentById_ThrowsException_WhenContinentDoesNotExist()
    {
        //1- Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continentId = 999; // ID que no existe en la base de datos
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(continentId)).ReturnsAsync((Continent)null); // Simulamos que no se encuentra el continente.

        var continentService = new ContinentService(mockContinentRepository.Object);

        //2- Act & Assert
        var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => continentService.GetContinentById(continentId));
        Assert.Equal("Continent not found", exception.Message); // Verificamos que el mensaje de la excepción sea el esperado
    }
}
