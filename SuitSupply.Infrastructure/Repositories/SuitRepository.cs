using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Suits.Entities;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class SuitRepository : GenericRepository<Suit>, ISuitRepository
{
	public SuitRepository(SuitSupplyDbContext _dbContext) : base(_dbContext) { }
}