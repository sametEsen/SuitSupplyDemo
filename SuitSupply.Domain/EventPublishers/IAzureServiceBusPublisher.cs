namespace SuitSupply.Domain.EventPublishers;
public interface IAzureServiceBusPublisher
{
	void PublishOrderCreatedEvent(int orderId);
	void PublishOrderPaidEvent(int orderId);
	void PublishStartAlterationEvent(int orderId);
	void PublishFinishAlterationEvent(int orderId);

}
