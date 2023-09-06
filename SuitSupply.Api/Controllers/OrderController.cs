using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuitSupply.Application.Services.Abstract;

namespace SuitSupply.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IAlterationService _alterationService;
		private readonly IOrderService _orderService;

		public OrderController(IAlterationService alterationService, IOrderService orderService)
		{
			_alterationService = alterationService;
			_orderService = orderService;
		}

		[HttpPost]
		[Route("~/CreateOrder")]
		public async Task<IActionResult> CreateOrder(int alterationFormId)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var alterationForm = await _alterationService.GetAlterationForm(alterationFormId);
			await _orderService.CreateOrder(alterationForm);
			return Ok();
		}

		[HttpGet("~/GetOrder/{orderIdId}")]
		public IActionResult GetOrder(int orderId)
		{
			var order = _orderService.GetOrderById(orderId);
			return Ok(order);
		}

		[HttpPost]
		[Route("~/PayOrder/{orderId}")]
		public async Task<IActionResult> PayOrder(int orderId)
		{
			await _orderService.PayOrder(orderId);
			return Ok();
		}

		[HttpPost]
		[Route("~/StartOrder/{orderId}")]
		public async Task<IActionResult> StartOrder(int orderId)
		{
			await _orderService.StartOrder(orderId);
			return Ok();
		}

		[HttpPost]
		[Route("~/FinishOrder/{orderId}")]
		public async Task<IActionResult> FinishOrder(int orderId)
		{
			await _orderService.FinishOrder(orderId);
			return Ok();
		}
	}
}
