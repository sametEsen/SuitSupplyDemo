using AutoMapper;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;

namespace SuitSupply.Application.Services.Concrete;
public class AlterationService : IAlterationService
{
    private readonly IMapper _mapper;
	private readonly IUnitOfWork uow;

    public AlterationService(IMapper mapper, IUnitOfWork _uow)
    {
        _mapper = mapper;
        uow = _uow;
    }

    public async Task<int> CreateAlterationForm(int suitId, List<AlterationInstructionDTO> instructionsDTO)
    {
        var suit = await uow.SuitRepository.GetById(suitId);
        if (suit == null)
        {
            throw new ArgumentException("Couldn't find any suit");
        }

        var instructions = _mapper.Map<List<AlterationInstruction>>(instructionsDTO);
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
