using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECommerceCampaign.Entity.Models
{
    public partial class CampaignDbContext : DbContext
    {
        public CampaignDbContext()
        {
        }

        public CampaignDbContext(DbContextOptions<CampaignDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignInfo> CampaignInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Name=(YourConnString)");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ratio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CampaignInfo>(entity =>
            {
                entity.ToTable("CampaignInfo");

                entity.Property(e => e.AverageItemPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Turnover).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
