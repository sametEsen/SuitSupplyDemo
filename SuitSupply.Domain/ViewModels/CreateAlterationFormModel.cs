using SuitSupply.Domain.Models.Alterations.Enums;
using SuitSupply.Domain.Models.Alterations.Values;

namespace SuitSupply.Domain.ViewModels;
public class CreateAlterationFormModel
{
	public int SuitId { get; set; }
	public List<AlterationInstruction> Instructions { get; set; }
}

//public class AlterationInstructionViewModel
//{
//	public AlterationType Type { get; set; }
//	public string Description { get; set; }
//	public float Measurement { get; set; }
//}
