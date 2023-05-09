using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Database;

public class TournamentContext : IdentityDbContext
{
	public TournamentContext(DbContextOptions<TournamentContext> options) : base(options) { }

	public DbSet<TurnamentResult> TurnamentResults { get; set; }
}