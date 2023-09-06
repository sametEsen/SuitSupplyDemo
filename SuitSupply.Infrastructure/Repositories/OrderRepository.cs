using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
	public OrderRepository(SuitSupplyDbContext _dbContext) : base(_dbContext) { }
}
