using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectPractica.Entities;

namespace ProiectPractica.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUserEntity>
    {
        // Add profile data for application users by adding properties to the ApplicationUser class

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<ProiectEntity> Proiecte { get; set; }
   
        public DbSet<TaskProiectEntity> Taskuri { get; set; }
        public DbSet<SubcontractorEntity> Subcontractori { get; set; }
        public DbSet<ResponsabilProiectEntity> ResponsabiliProiecte { get; set; }
        public DbSet<ActAditionalEntity> ActeAditionale { get; set; }
        public DbSet<PrelungireContractEntity> PrelungiriContracte { get; set; }
        public DbSet<ModificareValoareEntity> ModificariValoare { get; set; }
        public DbSet<ModificareLivrabileEntity> ModificariLivrabile { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProiectEntity>()
                .Property(p => p.ValoareContract)
                .HasPrecision(18, 2); // 18 cifre, 2 zecimale

            modelBuilder.Entity<ModificareValoareEntity>()
                .Property(m => m.ValoareNoua)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ActAditionalEntity>()
                .HasDiscriminator<string>("TipAct") // va crea o coloană discriminator în tabel
                .HasValue<ModificareValoareEntity>("ModificareValoare")
                .HasValue<PrelungireContractEntity>("PrelungireContract")
                .HasValue<ModificareLivrabileEntity>("ModificareLivrabile");

            modelBuilder.Entity<ResponsabilProiectEntity>()
    .HasKey(rp => rp.Id); // sau composite key dacă vrei

            modelBuilder.Entity<ResponsabilProiectEntity>()
                .HasOne(rp => rp.AppUser)
                .WithMany(u => u.ProiecteRepartizate)
                .HasForeignKey(rp => rp.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResponsabilProiectEntity>()
                .HasOne(rp => rp.Proiect)
                .WithMany(p => p.Responsabili)
                .HasForeignKey(rp => rp.Cod)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProiectEntity>()
                .HasMany(p => p.Livrabile)
                .WithOne(l => l.Proiect)
                .HasForeignKey(l => l.Cod)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProiectEntity>()
                .HasMany(p => p.Taskuri)
                .WithOne(t => t.Proiect)
                .HasForeignKey(t => t.Cod)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProiectEntity>()
                .HasMany(p => p.ActeAditionale)
                .WithOne(a => a.Proiect)
                .HasForeignKey(a => a.Cod)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<LivrabilEntity> Livrabile { get; set; }

    }
}
