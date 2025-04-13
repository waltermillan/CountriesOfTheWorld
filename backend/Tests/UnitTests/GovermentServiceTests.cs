using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Moq;

namespace Tests.UnitTests;

public class GovermentServiceTests
{
    public async Task GetGovermentById_ReturnGoverment_WhenGovermentExists()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new Goverment { Id = 9, Name = "Tests1"};
        mockGovermentRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(goverment);

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        var result = await govermentService.GetGovermentById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Tests1", result.Name);
        Assert.Equal(9, result.Id);
    }

    [Fact]
    public async Task GetAllGoverments_ReturnsGoverments_WhenGovermentsExists()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverments = new List<Goverment>
        {
            new Goverment { Id = 9, Name = "Test1" },
            new Goverment { Id = 13, Name = "Test2" }
        };
        mockGovermentRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(goverments);

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        var result = await govermentService.GetAllGoverments();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Test1");
        Assert.Contains(result, p => p.Name == "Test2");
    }

    [Fact]
    public void AddGoverment_AddsGoverment_WhenGovermentIsValid()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new Goverment { Id = 9, Name = "Goverment1" };

        mockGovermentRepository.Setup(repo => repo.Add(It.IsAny<Goverment>()));

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        govermentService.AddGoverment(goverment);

        // Assert
        mockGovermentRepository.Verify(repo => repo.Add(It.Is<Goverment>(c => c.Name == "Goverment1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void AddRange_AddsMultipleGoverments_WhenGovermentsAreValid()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new List<Goverment>
    {
        new Goverment { Id = 9, Name = "Goverment1" },
        new Goverment { Id = 13, Name = "Goverment2" }
    };

        mockGovermentRepository.Setup(repo => repo.AddRange(It.IsAny<IEnumerable<Goverment>>()));

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        govermentService.AddGoverments(goverment);

        // Assert
        mockGovermentRepository.Verify(repo => repo.AddRange(It.Is<IEnumerable<Goverment>>(c => c.Count() == 2 && c.Any(x => x.Name == "Goverment1") && c.Any(x => x.Name == "Goverment2"))), Times.Once);
    }

    [Fact]
    public void UpdateGoverment_UpdatesGoverment_WhenGovermentIsValid()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new Goverment { Id = 9, Name = "NewGoverment1" };

        mockGovermentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Goverment { Id = 9, Name = "NewGoverment1" });

        mockGovermentRepository.Setup(repo => repo.Add(It.IsAny<Goverment>()));

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        govermentService.UpdateGoverment(goverment);

        // Assert
        mockGovermentRepository.Verify(repo => repo.Update(It.Is<Goverment>(c => c.Name == "NewGoverment1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void DeleteGoverment_DeletesGoverment_WhenGovermentExists()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new Goverment { Id = 9, Name = "Goverment1" };

        mockGovermentRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Goverment { Id = 9, Name = "Goverment1" });

        mockGovermentRepository.Setup(repo => repo.Remove(It.IsAny<Goverment>()));

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act
        govermentService.DeleteGoverment(goverment);

        // Assert
        mockGovermentRepository.Verify(repo => repo.Remove(It.Is<Goverment>(c => c.Name == "Goverment1" && c.Id == 9)), Times.Once);
    }

    [Fact]
    public void UpdateContinent_ThrowsException_WhenContinentToUpdateDoesNotExist()
    {
        // Arrange
        var mockContinentRepository = new Mock<IContinentRepository>();
        var continent = new Continent { Id = 999, Name = "NonExistingContinent" };
        mockContinentRepository.Setup(repo => repo.GetByIdAsync(continent.Id)).ReturnsAsync((Continent)null);

        var continentService = new ContinentService(mockContinentRepository.Object);

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => continentService.UpdateContinent(continent));
        Assert.Equal("Continent to update not found", exception.Message);
    }

    [Fact]
    public void UpdateGoverment_ThrowsException_WhenGovermentToUpdateDoesNotExist()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var goverment = new Goverment { Id = 999, Name = "NonExistingGoverment" };
        mockGovermentRepository.Setup(repo => repo.GetByIdAsync(goverment.Id)).ReturnsAsync((Goverment)null);

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => govermentService.UpdateGoverment(goverment));
        Assert.Equal("Goverment to update not found", exception.Message);
    }

    [Fact]
    public async Task GetGovermentById_ThrowsException_WhenGovermentDoesNotExist()
    {
        // Arrange
        var mockGovermentRepository = new Mock<IGovermentRepository>();
        var govermentId = 999;
        mockGovermentRepository.Setup(repo => repo.GetByIdAsync(govermentId)).ReturnsAsync((Goverment)null);

        var govermentService = new GovermentService(mockGovermentRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => govermentService.GetGovermentById(govermentId));
        Assert.Equal("Goverment not found", exception.Message);
    }
}
