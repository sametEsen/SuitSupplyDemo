using Microsoft.AspNetCore.Mvc;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.ViewModels;

namespace SuitSupply.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AlterationController : ControllerBase
	{
		private readonly IAlterationService _alterationService;

		public AlterationController(IAlterationService alterationService)
		{
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
				return BadRequest(ex.Message);
			}
		}
	}
}
