using Microsoft.EntityFrameworkCore;
using Pubquizish.Game.Domain;

namespace Pubquizish.Game.Infrastructure.EntityFramework
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewGame>(builder =>
            {
                builder.Property("_code").HasColumnName("Code");
                builder.Property("_name").HasColumnName("Name");
                builder.Property("_creatorId").HasColumnName("CreatorId");
                builder.Property("_createdOn").HasColumnName("CreatedOn");
            });

            modelBuilder.Entity<PlayableGame>(builder =>
            {
                builder.Property("_code").HasColumnName("Code");
                builder.Property("_name").HasColumnName("Name");
                builder.Property("_creatorId").HasColumnName("CreatorId");
                builder.Property("_createdOn").HasColumnName("CreatedOn");
            });
        }
    }
}
