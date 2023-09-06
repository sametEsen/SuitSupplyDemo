namespace SuitSupply.Domain.DataTransfer.Entities;
public class OrderDTO
{
	public int Id { get; set; }
	public int AlterationFormId { get; set; }
	public bool IsPaid { get; set; }
	public bool IsStarted { get; set; }
}
