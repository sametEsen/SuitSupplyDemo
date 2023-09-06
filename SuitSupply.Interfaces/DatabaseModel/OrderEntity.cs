using SuitSupply.Interfaces.DatabaseModel.BaseModel;

namespace SuitSupply.Interfaces.DatabaseModel;
public class OrderEntity : BaseDatabaseModel
{
	public AlterationFormEntity Form { get; set; }
	public bool IsPaid { get; set; }
	public bool IsStarted { get; set; }
}
