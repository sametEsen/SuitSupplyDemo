using Microsoft.EntityFrameworkCore;
using SuitSupply.Domain.Models.Alterations.Entities;
using SuitSupply.Domain.Models.Orders.Entities;
using SuitSupply.Domain.Models.Suits.Entities;
using SuitSupply.Infrastructure.Extensions;

namespace SuitSupply.Infrastructure.Contexts
{
	public class SuitSupplyDbContext : DbContext
	{
		public SuitSupplyDbContext(DbContextOptions<SuitSupplyDbContext> options)
	   : base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ModelBuilderExtensions.Seed(modelBuilder);
		}
		public DbSet<Suit> Suits { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<AlterationForm> AlterationForms { get; set; }
	}
}
