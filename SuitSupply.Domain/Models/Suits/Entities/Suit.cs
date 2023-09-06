using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Suits.Enums;

namespace SuitSupply.Domain.Models.Suits.Entities;

public class Suit : IAggregateRoot
{
	public int Id { get; protected set; }
    public SuitType Type { get; private set; }
	public Suit() { }

	public Suit(SuitType type)
    {
        Type = type;
    }

	public AlterationForm CreateAlterationForm(List<AlterationInstruction> instructions)
	{
		return new AlterationForm(this, instructions);
    }
}