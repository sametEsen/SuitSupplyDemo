using AutoMapper;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Application.Services.Concrete;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Infrastructure.Contexts;
using SuitSupply.Infrastructure.Repositories;

namespace SuitSupply.Test.Services
{
	public class AlterationServiceTest
	{
        private Mock<IMapper> _mapperMock;
        private SuitSupplyDbContext _dbContextMock;
        private Mock<IUnitOfWork> _uowMock;
        private IAlterationService _alterationService;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _uowMock = new Mock<IUnitOfWork>();
            _dbContextMock = DbContextMock.Create();

            _uowMock.Setup(uow => uow.SuitRepository).Returns(new SuitRepository(_dbContextMock));
            _uowMock.Setup(uow => uow.AlterationFormRepository).Returns(new AlterationFormRepository(_dbContextMock));
            _alterationService = new AlterationService(_mapperMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task CreateAlterationForm_Should_Return_AlterationFormId()
        {
            //Arrange
            var alterationInstructions = new List<AlterationInstructionDTO>()
            {
                new AlterationInstructionDTO
                {
                    Type = Domain.Models.Alterations.Enums.AlterationType.JacketSleeve,
                    Description = "shorten sleeves",
                    Measurement = 5
                }
            };

            // Act
            var alterationFormId = await _alterationService.CreateAlterationForm(1, alterationInstructions);

            // Assert
            Assert.That(alterationFormId, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateAlterationForm_Should_Throw_Exception_On_Invalid_SuitId()
        {

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _alterationService.CreateAlterationForm(999, new List<AlterationInstructionDTO>());
            });
        }

        [Test]
        public async Task GetAlterationForm_Should_Return_AlterationForm()
        {
            // Act
            var alterationForm = await _alterationService.GetAlterationForm(1);

            // Assert
            Assert.NotNull(alterationForm);
        }
    }
}