using Microsoft.AspNetCore.Mvc;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.ViewModels;

namespace SuitSupply.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AlterationController : ControllerBase
	{
		private readonly ILogger<AlterationController> _logger;
		private readonly IAlterationService _alterationService;

		public AlterationController(ILogger<AlterationController> logger, IAlterationService alterationService)
		{
			_logger = logger;
			_alterationService = alterationService;
		}

		[HttpPost]
		[Route("~/CreateAlterationForm")]
		public async Task<IActionResult> CreateAlterationForm([FromBody] CreateAlterationFormModel createAlterationFormModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var alterationFormId = await _alterationService.CreateAlterationForm(createAlterationFormModel.SuitId, createAlterationFormModel.Instructions);
				return Ok(alterationFormId);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
			}
		}
	}
}
