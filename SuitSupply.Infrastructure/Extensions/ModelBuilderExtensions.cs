using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Alterations.Values;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Domain.Models.Suits.Entities;

namespace SuitSupply.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Suit>(op => op.HasKey("Id"));
		modelBuilder.Entity<Order>(op => op.HasKey("Id"));
		modelBuilder.Entity<AlterationForm>(op => op.HasKey("Id"));
		modelBuilder.Entity<AlterationInstruction>(op => op.HasNoKey());
	}
}
