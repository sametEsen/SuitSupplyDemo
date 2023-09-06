using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;

namespace SuitSupply.Application.Services.Concrete;
public class AlterationService : IAlterationService
{
    private readonly IUnitOfWork uow;

    public AlterationService(IUnitOfWork _uow)
    {
        uow = _uow;
    }

    public async Task<int> CreateAlterationForm(int suitId, List<AlterationInstruction> instructions)
    {
        var suit = await uow.SuitRepository.GetById(suitId);
        if (suit == null)
        {
            throw new Exception("Couldn't find any suit");
        }

        var alterationForm = suit.CreateAlterationForm(instructions);
        await uow.AlterationFormRepository.Add(alterationForm);
        await uow.SaveChangesAsync();

        return alterationForm.Id;
    }

	public async Task<AlterationForm> GetAlterationForm(int alterationFormId)
	{
        var alterationForm = await uow.AlterationFormRepository.GetById(alterationFormId);
        return alterationForm;
	}
}
