using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	protected readonly SuitSupplyDbContext _dbContext;
	private readonly DbSet<T> _dbSet;

	public GenericRepository(SuitSupplyDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = _dbContext.Set<T>();
	}

	public async Task Add(T entity) => await _dbSet.AddAsync(entity);

	public void Delete(T entity) => _dbSet.Remove(entity);

	public async Task<IEnumerable<T>> GetAll()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> GetById(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public void Update(T entity) => _dbSet.Update(entity);
}
