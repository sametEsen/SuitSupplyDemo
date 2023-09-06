using AutoMapper;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Application.Services.Concrete
{
	public class OrderService : IOrderService
	{
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public OrderService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task CreateOrder(AlterationForm alterationForm)
        {
            var order = alterationForm.CreateOrder();
            await _uow.OrderRepository.Add(order);
            await _uow.SaveChangesAsync();
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
            await _uow.SaveChangesAsync();
        }

        public async Task StartOrder(int orderId)
		{
            var order = await _uow.OrderRepository.GetById(orderId);
            order.MarkAsStarted();
			await _uow.SaveChangesAsync();
        }

        public async Task FinishOrder(int orderId)
        {
            var order = await _uow.OrderRepository.GetById(orderId);
            order.MarkAsFinished();
			await _uow.SaveChangesAsync();
        }
    }
}
