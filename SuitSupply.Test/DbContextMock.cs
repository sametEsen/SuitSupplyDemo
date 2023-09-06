using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Domain.Models.Suits.Entities;
using SuitSupply.Domain.Models.Suits.Enums;
using SuitSupply.Infrastructure.Contexts;

namespace SuitSupply.Test
{
	public class DbContextMock
	{
		public static SuitSupplyDbContext Create()
		{
			var options = new DbContextOptionsBuilder<SuitSupplyDbContext>()
				.UseInMemoryDatabase(databaseName: "InMemoryDatabase")
				.Options;

			var context = new SuitSupplyDbContext(options);
			SeedTestData(context);
			return context;
		}

		private static void SeedTestData(SuitSupplyDbContext context)
		{
			var dummySuit = new Suit(SuitType.Jacket);
			context.Suits.Add(dummySuit);
			var dummyAlterationInstructions = new List<AlterationInstruction>()
			{
				new AlterationInstruction
				(
					Domain.Models.Alterations.Enums.AlterationType.JacketSleeve,
					"shorten sleeves",
					5
				)
			};
			var dummyAlterationForm = new AlterationForm(dummySuit, dummyAlterationInstructions);
			context.AlterationForms.Add(dummyAlterationForm);

			var dummyOrder = new Order(dummyAlterationForm);
			context.Orders.Add(dummyOrder);
			context.SaveChanges();
		}
	}
}
