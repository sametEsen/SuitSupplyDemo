using AutoMapper;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Application.Services.Concrete;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.EventPublishers;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Infrastructure.Contexts;
using SuitSupply.Infrastructure.Repositories;

namespace SuitSupply.Test.Services
{
	public class OrderServiceTest
	{
		private Mock<IMapper> _mapperMock;
		private SuitSupplyDbContext _dbContextMock;
		private Mock<IUnitOfWork> _uowMock;
		private Mock<IAzureServiceBusPublisher> _azureServiceBusPublisherMock;
		private IOrderService _orderService;

		[SetUp]
		public void Setup()
		{
			_mapperMock = new Mock<IMapper>();
			_uowMock = new Mock<IUnitOfWork>();
			_azureServiceBusPublisherMock = new Mock<IAzureServiceBusPublisher>();
			_dbContextMock = DbContextMock.Create();

			_uowMock.Setup(uow => uow.SuitRepository).Returns(new SuitRepository(_dbContextMock));
			_uowMock.Setup(uow => uow.AlterationFormRepository).Returns(new AlterationFormRepository(_dbContextMock));
			_uowMock.Setup(uow => uow.OrderRepository).Returns(new OrderRepository(_dbContextMock));
			_orderService = new OrderService(_mapperMock.Object, _uowMock.Object, _azureServiceBusPublisherMock.Object);
		}

		[Test]
		public async Task CreateOrder_WithValidAlterationForm_ShouldCreateOrder()
		{
			// Arrange
			var dummySuit = _uowMock.Object.SuitRepository.GetAll().GetAwaiter().GetResult().FirstOrDefault();
			var alterationInstructions = new List<AlterationInstruction>()
			{
				new AlterationInstruction(Domain.Models.Alterations.Enums.AlterationType.JacketSleeve,"shorten sleeves",5)
			};
			var alterationForm = new AlterationForm(dummySuit, alterationInstructions);

			// Act
			await _orderService.CreateOrder(alterationForm);

			// Assert
			_uowMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
		}

		[Test]
		public async Task GetOrderById_WithInvalidOrderId_ShouldReturnNull()
		{
			// Arrange
			var orderId = 123; // Set an invalid order ID

			// Mock the behavior of the OrderRepository to return null
			_uowMock.Setup(uow => uow.OrderRepository.GetById(orderId))
				.ReturnsAsync((Order)null);

			// Act - Call the method under test
			var result = await _orderService.GetOrderById(orderId);

			// Assert
			Assert.IsNull(result);
		}

		[Test]
		public async Task PayOrder_WithValidOrderId_ShouldMarkedAsPaid()
		{
			// Arrange
			var dummyOrder = _uowMock.Object.OrderRepository.GetAll().GetAwaiter().GetResult().FirstOrDefault();

			// Act
			await _orderService.PayOrder(dummyOrder.Id);

			// Assert
			Assert.That(dummyOrder.IsPaid, Is.EqualTo(true));
		}

		[Test]
		public async Task StartOrder_WithValidOrderId_ShouldMarkedAsStarted()
		{
			// Arrange
			var dummyOrder = _uowMock.Object.OrderRepository.GetAll().GetAwaiter().GetResult().FirstOrDefault();
			dummyOrder.IsPaid = true;
			// Act
			await _orderService.StartOrder(dummyOrder.Id);

			// Assert
			Assert.That(dummyOrder.IsStarted, Is.EqualTo(true));
		}

		[Test]
		public async Task StartOrder_WithValidNotPaidOrderId_ShouldThrowException()
		{
			// Arrange
			var dummyOrder = _uowMock.Object.OrderRepository.GetAll().GetAwaiter().GetResult().FirstOrDefault();

			//Act & Assert
			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _orderService.StartOrder(dummyOrder.Id);
			});
		}

		[Test]
		public async Task FinishOrder_WithValidOrderIdAndAlreadyPaid_ShouldMarkedAsStartedFalse()
		{
			// Arrange
			var dummyOrder = _uowMock.Object.OrderRepository.GetAll().GetAwaiter().GetResult().FirstOrDefault();
			dummyOrder.IsPaid = true;
			// Act
			await _orderService.FinishOrder(dummyOrder.Id);

			// Assert
			Assert.That(dummyOrder.IsStarted, Is.EqualTo(false));
		}
	}
}
