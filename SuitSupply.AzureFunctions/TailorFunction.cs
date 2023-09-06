using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace SuitSupply.AzureFunctions
{
	public class TailorFunction
    {
        private readonly ILogger<TailorFunction> _logger;

        public TailorFunction(ILogger<TailorFunction> log)
        {
            _logger = log;
        }

        [FunctionName("TailorFunction")]
        public void Run([ServiceBusTrigger("OrderPaid", "TailorSubscription", Connection = "useProperConnectionSeting")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
