using SuitSupply.Domain.Models.Alterations.Enums;

namespace SuitSupply.Domain.Models.Alterations.Values;

public class AlterationInstruction
{
    public AlterationType Type { get; private set; }
    public string Description { get; private set; }
    public float Measurement { get; private set; }
	public AlterationInstruction() { }

	public AlterationInstruction(AlterationType type, string description, float measurement)
    {
        Type = type;
        Description = description;
        if (!IsValidMeasurement(measurement))
        {
            throw new ArgumentException("Invalid measurement.");
        }

        Measurement = measurement;
    }

    private bool IsValidMeasurement(float measurement)
    {
        return measurement >= -5 && measurement <= 5;
    }
}
