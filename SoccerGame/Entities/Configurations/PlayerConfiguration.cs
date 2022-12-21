namespace SoccerGame
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique(false);

            builder.HasOne(p => p.Team).WithMany(t => t.Players).HasForeignKey(p => p.TeamId);
        }
    }
}