using AutoMapper;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.EventPublishers;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Application.Services.Concrete
{
	public class OrderService : IOrderService
	{
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IAzureServiceBusPublisher _azureServiceBusPublisher;
		public OrderService(IMapper mapper, IUnitOfWork uow, IAzureServiceBusPublisher azureServiceBusPublisher)
        {
            _mapper = mapper;
            _uow = uow;
            _azureServiceBusPublisher = azureServiceBusPublisher;
        }

        public async Task CreateOrder(AlterationForm alterationForm)
        {
            var order = alterationForm.CreateOrder();
			await _uow.OrderRepository.Add(order);
            await _uow.SaveChangesAsync();
			_azureServiceBusPublisher.PublishOrderCreatedEvent(order.Id);
		}

        public async Task<OrderDTO> GetOrderById(int orderId)
        {
            var order = await _uow.OrderRepository.GetById(orderId);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task PayOrder(int orderId)
        {
            var order = await _uow.OrderRepository.GetById(orderId);
            order.MarkAsPaid();
            _azureServiceBusPublisher.PublishOrderPaidEvent(orderId);
			await _uow.SaveChangesAsync();
        }

        public async Task StartOrder(int orderId)
		{
            var order = await _uow.OrderRepository.GetById(orderId);
            order.MarkAsStarted();
			_azureServiceBusPublisher.PublishStartAlterationEvent(orderId);
			await _uow.SaveChangesAsync();
        }

        public async Task FinishOrder(int orderId)
        {
            var order = await _uow.OrderRepository.GetById(orderId);
            order.MarkAsFinished();
			_azureServiceBusPublisher.PublishFinishAlterationEvent(orderId);
			await _uow.SaveChangesAsync();
        }
    }
}
