namespace SoccerGame
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique(false);

            builder.HasMany(t => t.Players).WithOne(t => t.Team).HasForeignKey(p => p.TeamId);
        }
    }
}