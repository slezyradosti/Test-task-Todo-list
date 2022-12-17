using Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Type = Domain.EntityModels.Type;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Notes> Notes { get; set; }
		public DbSet<Type> Types { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Notes>()
				.HasOne(e => e.Type)
				.WithMany(e => e.NotesList)
				.HasForeignKey(e => e.TypeId)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
		}
	}
}
