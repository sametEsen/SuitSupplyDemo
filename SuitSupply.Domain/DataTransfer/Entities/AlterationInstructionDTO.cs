using SuitSupply.Domain.Models.Alterations.Enums;

namespace SuitSupply.Domain.DataTransfer.Entities;
public class AlterationInstructionDTO
{
	public AlterationType Type { get; set; }
	public string Description { get; set; }
	public float Measurement { get; set; }
}
