using SuitSupply.Domain.DataTransfer.Entities;

namespace SuitSupply.Domain.ViewModels;
public class CreateAlterationFormModel
{
	public int SuitId { get; set; }
	public List<AlterationInstructionDTO> Instructions { get; set; }
}
