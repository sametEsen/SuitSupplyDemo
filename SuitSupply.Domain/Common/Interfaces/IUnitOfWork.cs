namespace SuitSupply.Domain.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
	ISuitRepository SuitRepository { get; }
	IOrderRepository OrderRepository { get; }
	IAlterationFormRepository AlterationFormRepository { get; }
	Task<int> SaveChangesAsync();
}
