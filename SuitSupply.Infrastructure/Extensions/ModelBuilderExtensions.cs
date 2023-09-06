using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Domain.Models.Suits.Entities;
using SuitSupply.Domain.Models.Suits.Enums;

namespace SuitSupply.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Suit>(op => op.HasKey("Id"));
		modelBuilder.Entity<Order>(op =>
		{
			op.HasKey("Id");
			op.Ignore("AlterationForm");
		});
		modelBuilder.Entity<AlterationForm>(op =>
		{
			op.HasKey("Id");
			op.Ignore("Suit");
			op.Ignore("AlterationInstructions");
		});
		modelBuilder.Entity<AlterationInstruction>(op => op.HasNoKey());
	}
}
