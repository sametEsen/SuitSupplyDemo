using SuitSupply.Domain.Models.Suits.Enums;

namespace SuitSupply.Domain.DataTransfer.Entities;
public class SuitDTO
{
	public int Id { get; set; }
	public SuitType Type { get; set; }
}
