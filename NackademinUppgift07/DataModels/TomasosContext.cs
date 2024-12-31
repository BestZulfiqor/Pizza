using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NackademinUppgift07.DataModels
{
    public partial class TomasosContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Bestallning> Bestallning { get; set; }
        public virtual DbSet<BestallningMatratt> BestallningMatratt { get; set; }
        public virtual DbSet<Matratt> Matratt { get; set; }
        public virtual DbSet<MatrattProdukt> MatrattProdukt { get; set; }
        public virtual DbSet<MatrattTyp> MatrattTyp { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }

        public TomasosContext(DbContextOptions<TomasosContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bestallning>(entity =>
            {
                entity.Property(e => e.BestallningId).HasColumnName("BestallningID");
                entity.Property(e => e.BestallningDatum).HasColumnType("TEXT");
                entity.Property(e => e.KundId).HasColumnName("KundID");
                entity.Property(e => e.Totalbelopp).HasColumnType("DECIMAL(18,2)");
                entity.Property(e => e.Rabatt).HasColumnType("DECIMAL(18,2)");

                entity.HasOne(d => d.Kund)
                    .WithMany(p => p.Bestallning)
                    .HasForeignKey(d => d.KundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bestallning_Kund");
            });

            modelBuilder.Entity<BestallningMatratt>(entity =>
            {
                entity.HasKey(e => new { e.MatrattId, e.BestallningId });
                entity.Property(e => e.MatrattId).HasColumnName("MatrattID");
                entity.Property(e => e.BestallningId).HasColumnName("BestallningID");
                entity.Property(e => e.Antal).HasDefaultValue(1);

                entity.HasOne(d => d.Bestallning)
                    .WithMany(p => p.BestallningMatratt)
                    .HasForeignKey(d => d.BestallningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BestallningMatratt_Bestallning");

                entity.HasOne(d => d.Matratt)
                    .WithMany(p => p.BestallningMatratt)
                    .HasForeignKey(d => d.MatrattId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BestallningMatratt_Matratt");
            });

            modelBuilder.Entity<Matratt>(entity =>
            {
                entity.Property(e => e.MatrattId).HasColumnName("MatrattID");
                entity.Property(e => e.Beskrivning).HasColumnType("TEXT").HasMaxLength(200);
                entity.Property(e => e.MatrattNamn).HasColumnType("TEXT").HasMaxLength(50).IsRequired();

                entity.HasOne(d => d.MatrattTypNavigation)
                    .WithMany(p => p.Matratt)
                    .HasForeignKey(d => d.MatrattTyp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matratt_MatrattTyp");
            });

            modelBuilder.Entity<MatrattProdukt>(entity =>
            {
                entity.HasKey(e => new { e.MatrattId, e.ProduktId });
                entity.Property(e => e.MatrattId).HasColumnName("MatrattID");
                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");

                entity.HasOne(d => d.Matratt)
                    .WithMany(p => p.MatrattProdukt)
                    .HasForeignKey(d => d.MatrattId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatrattProdukt_Matratt");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.MatrattProdukt)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatrattProdukt_Produkt");
            });

            modelBuilder.Entity<MatrattTyp>(entity =>
            {
                entity.HasKey(e => e.MatrattTyp1);
                entity.Property(e => e.MatrattTyp1).HasColumnName("MatrattTyp");
                entity.Property(e => e.Beskrivning).HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");
                entity.Property(e => e.ProduktNamn).HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            });
        }
    }
}
