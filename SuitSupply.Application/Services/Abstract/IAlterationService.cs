using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Application.Services.Abstract;

public interface IAlterationService
{
	Task<int> CreateAlterationForm(int suitId, List<AlterationInstructionDTO> instructionsDTO);
	Task<AlterationForm> GetAlterationForm(int alterationFormId);
}
