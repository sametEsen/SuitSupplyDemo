using Microsoft.Azure.Amqp;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Application.Services.Concrete
{
    public class OrderService : IOrderService
	{
        private readonly IUnitOfWork uow;
        public OrderService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public async Task CreateOrder(AlterationForm alterationForm)
        {
            var order = alterationForm.CreateOrder();
            await uow.OrderRepository.Add(order);
            await uow.SaveChangesAsync();
        }

        public async Task PayOrder(int orderId)
        {
            var order = await uow.OrderRepository.GetById(orderId);
            order.MarkAsPaid();
            await uow.SaveChangesAsync();
        }

        public async Task StartOrder(int orderId)
		{
            var order = await uow.OrderRepository.GetById(orderId);
            order.MarkAsStarted();
			await uow.SaveChangesAsync();
        }

        public async Task FinishOrder(int orderId)
        {
            var order = await uow.OrderRepository.GetById(orderId);
            order.MarkAsFinished();
			await uow.SaveChangesAsync();
        }
    }
}
