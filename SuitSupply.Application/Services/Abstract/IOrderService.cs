using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Application.Services.Abstract;

public interface IOrderService
{
	Task CreateOrder(AlterationForm alterationForm);

	Task<OrderDTO> GetOrderById(int orderId);

	Task PayOrder(int orderId);

	Task StartOrder(int orderId);

	Task FinishOrder(int orderId);
}
