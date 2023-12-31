﻿using Azure.Messaging.ServiceBus;
using SuitSupply.Domain.EventPublishers.Models;

namespace SuitSupply.Domain.EventPublishers
{
	public class AzureServiceBusPublisher : IAzureServiceBusPublisher
	{
		private readonly string serviceBusConnectionString = "<YourConnectionString>";
		public void PublishOrderCreatedEvent(int orderId)
		{
			PublishEvent(new EventModel
			{
				TopicName = "OrderCreated",
				Message = $"The Order Id: {orderId} has been created and ready for the payment."
			}).GetAwaiter().GetResult();
		}

		public void PublishOrderPaidEvent(int orderId)
		{
			PublishEvent(new EventModel
			{
				TopicName = "OrderPaid",
				Message = $"The Order Id: {orderId} has been paid and ready for the alteration."
			}).GetAwaiter().GetResult();
		}

		public void PublishStartAlterationEvent(int orderId)
		{
			PublishEvent(new EventModel
			{
				TopicName = "AlterationStarted",
				Message = $"The alteration for the order Id: {orderId} has been started."
			}).GetAwaiter().GetResult();
		}

		public void PublishFinishAlterationEvent(int orderId)
		{
			PublishEvent(new EventModel
			{
				TopicName = "AlterationFinished",
				Message = $"The alteration for the order Id: {orderId} has been completed."
			}).GetAwaiter().GetResult();
		}

		private async Task PublishEvent(EventModel eventModel)
		{
			await using (var client = new ServiceBusClient(serviceBusConnectionString))
			{
				var sender = client.CreateSender(eventModel.TopicName);
				var message = new ServiceBusMessage(eventModel.Message);

				// Send the message to the Azure Service Bus Topic
				await sender.SendMessageAsync(message);
			}
		}
	}
}
