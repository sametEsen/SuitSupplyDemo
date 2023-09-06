using SuitSupply.Interfaces.DatabaseModel.BaseModel;

namespace SuitSupply.Interfaces.DatabaseModel;

public class SuitEntity : BaseDatabaseModel
{
    public byte Type { get; set; }
}
