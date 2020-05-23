using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.UseCases.DataSource;
using Moq;
using Xunit;

namespace EllAid.Tests.UseCases.DataSource
{
    public class SaveFacultyUseCaseTests
    {
        List<Dto> dtos = new List<Dto>();
        List<Dto> identityDtos = new List<Dto>();

        [Fact]
        public async Task Save_SendsInstructorsAndIdentitiesToRepository()
        {
            // Given
            SaveFacultyUseCase<Instructor, Dto, Dto> useCase = GetUseCase<Instructor, Dto, Dto>();
            List<Instructor> entities = GetFaculty<Instructor>();

            // When
            await useCase.SaveAsync(entities);
            // Then
            Assert.Equal(entities.Count, dtos.Count);
            Assert.Equal(entities.Count, identityDtos.Count);
        }

        SaveFacultyUseCase<S, T, U> GetUseCase<S, T, U>() where S : Person where T : Dto, new() where U : Dto, new()
        {
            Mock<IMappingProvider> mappingMock = new Mock<IMappingProvider>();
            mappingMock.Setup(prov => prov.Map<T, S>(It.IsAny<S>())).Returns(new T());
            mappingMock.Setup(prov => prov.Map<U, S>(It.IsAny<S>())).Returns(new U());

            Mock<IFacultyRepository<T>> repositoryMock = new Mock<IFacultyRepository<T>>();
            repositoryMock.Setup(rep => rep.SaveFacultyAsync(It.IsAny<List<T>>())).Callback<List<Dto>>((obj) => dtos = obj);

            Mock<IIdentityRepository<U>> identityRepositoryMock = new Mock<IIdentityRepository<U>>();
            identityRepositoryMock.Setup(rep => rep.SaveAsync(It.IsAny<List<U>>())).Callback<List<Dto>>((obj) => identityDtos = obj);

            SaveFacultyUseCase<S, T, U> useCase = new SaveFacultyUseCase<S, T, U>(repositoryMock.Object, identityRepositoryMock.Object, mappingMock.Object);
            return useCase;
        }

        List<S> GetFaculty<S>() where S : Person, new() => new List<S>() { new S(), new S(), new S() };

        public class Dto{}

        [Fact]
        public async Task Save_SendsAssistantsToRepository()
        {
            // Given
            SaveFacultyUseCase<Assistant, Dto, Dto> useCase = GetUseCase<Assistant, Dto, Dto>();
            List<Assistant> entities = GetFaculty<Assistant>();

            // When
            await useCase.SaveAsync(entities);
            // Then
            Assert.Equal(entities.Count, dtos.Count);
            Assert.Equal(entities.Count, identityDtos.Count);
        }

        [Fact]
        public async Task Save_SendsCoachesToRepository()
        {
            // Given
            SaveFacultyUseCase<EllCoach, Dto, Dto> useCase = GetUseCase<EllCoach, Dto, Dto>();
            List<EllCoach> entities = GetFaculty<EllCoach>();

            // When
            await useCase.SaveAsync(entities);
            // Then
            Assert.Equal(entities.Count, dtos.Count);
            Assert.Equal(entities.Count, identityDtos.Count);
        }
    }
}