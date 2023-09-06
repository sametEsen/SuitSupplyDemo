namespace SuitSupply.Interfaces.DatabaseModel.BaseModel;
public abstract class BaseDatabaseModel
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
