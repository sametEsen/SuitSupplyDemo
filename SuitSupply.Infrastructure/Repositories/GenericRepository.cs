using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	protected readonly SuitSupplyDbContext dbContext;
	private readonly DbSet<T> dbSet;

	public GenericRepository(SuitSupplyDbContext _dbContext)
	{
		this.dbContext = _dbContext;
		this.dbSet = dbContext.Set<T>();
	}

	public async Task Add(T entity) => await dbSet.AddAsync(entity);

	public void Delete(T entity) => dbSet.Remove(entity);

	public async Task<IEnumerable<T>> GetAll()
	{
		return await dbSet.ToListAsync();
	}

	public async Task<T> GetById(int id)
	{
		return await dbSet.FindAsync(id);
	}

	public void Update(T entity) => dbSet.Update(entity);
}
