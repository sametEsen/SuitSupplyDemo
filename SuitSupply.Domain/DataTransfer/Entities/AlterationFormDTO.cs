namespace SuitSupply.Domain.DataTransfer.Entities;
public class AlterationFormDTO
{
	public int Id { get; set; }
	public int SuitId { get; set; }
	public List<AlterationInstructionDTO> AlterationInstructions { get; set; }
}
