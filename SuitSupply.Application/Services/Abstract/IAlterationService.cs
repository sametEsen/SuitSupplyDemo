using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;

namespace SuitSupply.Application.Services.Abstract;

public interface IAlterationService
{
	Task<int> CreateAlterationForm(int suitId, List<AlterationInstruction> instructions);
	Task<AlterationForm> GetAlterationForm(int alterationFormId);
}
