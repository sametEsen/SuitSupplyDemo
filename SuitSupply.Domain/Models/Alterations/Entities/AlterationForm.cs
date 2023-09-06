using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Domain.Models.Suits.Entities;

namespace SuitSupply.Domain.Models.Alterations.Entities;

public class AlterationForm : IAggregateRoot
{
	public int Id { get; protected set; }
	public Suit Suit { get; private set; }
	public List<AlterationInstruction> AlterationInstructions { get; private set; }
	public AlterationForm() { }
	public AlterationForm(Suit suit, List<AlterationInstruction> alterationInstructions)
    {
        Suit = suit;
        AlterationInstructions = alterationInstructions;
	}

	public Order CreateOrder()
	{
		var order = new Order(this);

		return order;
	}
}
