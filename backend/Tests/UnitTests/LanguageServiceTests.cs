using Core.Entities;
using Core.Interfases;
using Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UnitTests
{
    public class LanguageServiceTests
    {
        [Fact]
        public async Task GetLanguageById_ReturnsLanguage_WhenLanguageExists()
        {
            // Arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var language = new Language { Id = 1, Name = "Test1" };
            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(language);

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // Act
            var result = await languageService.GetLanguageById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test1", result.Name);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetAllLanguages_ReturnsLanguages_WhenLanguagesExist()
        {
            // Arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var languages = new List<Language>
        {
            new Language { Id = 1, Name = "Language1" },
            new Language { Id = 2, Name = "Language2" }
        };
            mockLanguageRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(languages);

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // Act
            var result = await languageService.GeAllLanguages();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Usamos Count() para contar los elementos
            Assert.Contains(result, p => p.Name == "Language1");
            Assert.Contains(result, p => p.Name == "Language2");
        }

        [Fact]
        public void AddLanguage_AddsLanguage_WhenLanguageIsValid()
        {
            // arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var language = new Language { Id = 9, Name = "Language1" };

            mockLanguageRepository.Setup(repo => repo.Add(It.IsAny<Language>()));

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // act
            languageService.AddLanguage(language);

            // assert
            mockLanguageRepository.Verify(repo => repo.Add(It.Is<Language>(c => c.Name == "Language1" && c.Id == 9)), Times.Once);
        }

        [Fact]
        public void AddRange_AddsMultipleLanguages_WhenLanguagesAreValid()
        {
            // Arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var languages = new List<Language>
                {
                    new Language { Id = 9, Name = "Language1" },
                    new Language { Id = 13, Name = "Language2" }
                };

            // Configuramos el mock para verificar que AddRange sea llamado con la lista correcta de gobiernos
            mockLanguageRepository.Setup(repo => repo.AddRange(It.IsAny<IEnumerable<Language>>()));

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // Act
            languageService.AddLanguages(languages);

            // Assert
            mockLanguageRepository.Verify(repo => repo.AddRange(It.Is<IEnumerable<Language>>(c => c.Count() == 2 && c.Any(x => x.Name == "Language1") && c.Any(x => x.Name == "Language2"))), Times.Once);
        }

        [Fact]
        public void UpdateLanguage_UpdatesLanguage_WhenLanguageIsValid()
        {
            // arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var language = new Language { Id = 9, Name = "NewLanguage1" };

            // Configuramos el mock para que devuelva el lenguaje que estamos eliminando
            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Language { Id = 9, Name = "NewLanguage1" }); // Simulamos que el continente con Id 9 existe


            mockLanguageRepository.Setup(repo => repo.Add(It.IsAny<Language>()));

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // act
            languageService.UpdateLanguage(language);

            // assert
            mockLanguageRepository.Verify(repo => repo.Update(It.Is<Language>(c => c.Name == "NewLanguage1" && c.Id == 9)), Times.Once);
        }

        [Fact]
        public void DeleteLanguage_DeletesLanguage_WhenLanguageExists()
        {
            // arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var language = new Language { Id = 9, Name = "Language1" };

            // Configuramos el mock para que devuelva el lenguage que estamos eliminando
            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Language { Id = 9, Name = "Language1" }); // Simulamos que el languaje con Id 9 existe

            mockLanguageRepository.Setup(repo => repo.Remove(It.IsAny<Language>()));

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // act
            languageService.DeleteLanguage(language);

            // assert
            mockLanguageRepository.Verify(repo => repo.Remove(It.Is<Language>(c => c.Name == "Language1" && c.Id == 9)), Times.Once);
        }

        [Fact]
        public void UpdateLanguage_ThrowsException_WhenLanguageToUpdateDoesNotExist()
        {
            // Arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var language = new Language { Id = 999, Name = "Language" }; // ID que no existe
            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(language.Id)).ReturnsAsync((Language)null); // Simulamos que el continente no existe.

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => languageService.UpdateLanguage(language));
            Assert.Equal("Language to update not found", exception.Message); // Verificamos que el mensaje de la excepción sea el esperado
        }

        [Fact]
        public async Task GetLanguageById_ThrowsException_WhenLanguageDoesNotExist()
        {
            // Arrange
            var mockLanguageRepository = new Mock<ILanguageRepository>();
            var languageId = 999; // ID que no existe en la base de datos

            // Configuramos el mock para que devuelva el lenguage que estamos buscando
            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(9)).ReturnsAsync(new Language { Id = 999, Name = "Language" }); // Simulamos que el languaje con Id 999 que no existe

            mockLanguageRepository.Setup(repo => repo.GetByIdAsync(languageId)).ReturnsAsync((Language)null); // Simulamos que no se encuentra el continente.

            var languageService = new LanguageService(mockLanguageRepository.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => languageService.GetLanguageById(languageId));
            Assert.Equal("Language not found", exception.Message); // Verificamos que el mensaje de la excepción sea el esperado
        }
    }
}
