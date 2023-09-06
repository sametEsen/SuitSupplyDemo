using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class AlterationFormRepository : GenericRepository<AlterationForm>, IAlterationFormRepository
{
	public AlterationFormRepository(SuitSupplyDbContext _dbContext) : base(_dbContext) { }
}
