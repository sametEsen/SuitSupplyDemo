using SuitSupply.Interfaces.DatabaseModel.BaseModel;

namespace SuitSupply.Interfaces.DatabaseModel;
public class AlterationInstructionEntity: BaseDatabaseModel
{
    public byte Type { get; set; }
    public string Description { get; set; }
	public float Measurement { get; set; }
}
