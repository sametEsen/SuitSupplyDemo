using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly SuitSupplyDbContext _dbContext;

	public ISuitRepository SuitRepository { get; }

	public IOrderRepository OrderRepository { get; }

	public IAlterationFormRepository AlterationFormRepository { get; }

	public UnitOfWork(SuitSupplyDbContext dbContext)
	{
		_dbContext = dbContext;
		this.SuitRepository = new SuitRepository(_dbContext);
		this.OrderRepository = new OrderRepository(_dbContext);
		this.AlterationFormRepository = new AlterationFormRepository(_dbContext);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_dbContext.Dispose();
		}
	}

	public async Task<int> SaveChangesAsync()
	{
		return await this._dbContext.SaveChangesAsync();
	}
}
