using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.EventPublishers;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Domain.Models.Orders.Entities;

public class Order : IAggregateRoot
{
	public int Id { get; protected set; }
	public AlterationForm Form { get; private set; }
	public bool IsPaid { get; set; } = false;
	public bool IsStarted { get; set; } = false;
	public Order() { }
	public Order(AlterationForm alterationForm)
	{
		Form = alterationForm;
	}

	public void MarkAsPaid()
	{
		IsPaid = true;

		AzureServiceBusPublisher.PublishOrderPaidEvent(Id);
	}

	public void MarkAsStarted()
	{
		if (!IsPaid)
		{
			throw new ArgumentException("Order has not been paid yet!");
		}

		IsStarted = true;

		AzureServiceBusPublisher.PublishStartAlterationEvent(Id);
	}

	public void MarkAsFinished()
	{
		if (!IsPaid)
		{
			throw new ArgumentException("Order has not been paid yet!");
		}

		if (IsStarted)
		{
			throw new ArgumentException("Order has already been started!");
		}

		IsStarted = false;

		AzureServiceBusPublisher.PublishFinishAlterationEvent(Id);

	}

}