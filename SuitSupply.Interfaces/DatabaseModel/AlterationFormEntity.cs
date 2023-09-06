using SuitSupply.Interfaces.DatabaseModel.BaseModel;

namespace SuitSupply.Interfaces.DatabaseModel;
public class AlterationForm : BaseDatabaseModel
{
    public Suit Suit { get; set; }
    public List<AlterationInstruction> Instructions { get; set; }
}
