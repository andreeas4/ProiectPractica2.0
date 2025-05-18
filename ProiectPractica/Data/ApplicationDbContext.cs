using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectPractica.Entities;

namespace ProiectPractica.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserSelectedProject> UserSelectedProjects { get; set; }
        public DbSet<ProiectEntity> Proiecte { get; set; }
        public DbSet<TaskProiectEntity> Taskuri { get; set; }
        public DbSet<SubcontractorEntity> Subcontractori { get; set; }
        public DbSet<ResponsabilProiectEntity> ResponsabiliProiecte { get; set; }
        public DbSet<ActAditionalEntity> ActeAditionale { get; set; }
        public DbSet<PrelungireContractEntity> PrelungiriContracte { get; set; }
        public DbSet<ModificareValoareEntity> ModificariValoare { get; set; }
        public DbSet<ModificareLivrabileEntity> ModificariLivrabile { get; set; }
        public DbSet<LivrabilEntity> Livrabile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many: ProiectEntity <-> SubcontractorEntity
            modelBuilder.Entity<ProiectEntity>()
                .HasMany(p => p.Subcontractori)
                .WithMany(s => s.Proiecte)
                .UsingEntity(j => j.ToTable("ProiectSubcontractori"));

            // Many-to-many: ProiectEntity <-> AppUserEntity (via ResponsabilProiectEntity for responsible projects)
            modelBuilder.Entity<ResponsabilProiectEntity>()
                .HasKey(rp => rp.Id);

            modelBuilder.Entity<ResponsabilProiectEntity>()
                .HasOne(rp => rp.AppUser)
                .WithMany(u => u.ProiecteRepartizate) // Use ProiecteRepartizate instead of SelectedProjects
                .HasForeignKey(rp => rp.AppUserId);

            modelBuilder.Entity<ResponsabilProiectEntity>()
                .HasOne(rp => rp.Proiect)
                .WithMany(p => p.Responsabili)
                .HasForeignKey(rp => rp.Cod);

            // Many-to-many: AppUserEntity <-> ProiectEntity (via UserSelectedProject for selected projects)
            modelBuilder.Entity<UserSelectedProject>()
                .HasKey(up => new { up.UserId, up.ProiectId });

            modelBuilder.Entity<UserSelectedProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.SelectedProjects)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserSelectedProject>()
                .HasOne(up => up.Proiect)
                .WithMany() // No inverse navigation property for selected projects
                .HasForeignKey(up => up.ProiectId);

            // Precision for decimal properties
            modelBuilder.Entity<ProiectEntity>()
                .Property(p => p.ValoareContract)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ModificareValoareEntity>()
                .Property(m => m.ValoareNoua)
                .HasPrecision(18, 2);

            // Discriminator for ActAditionalEntity inheritance
            modelBuilder.Entity<ActAditionalEntity>()
                .HasDiscriminator<string>("TipAct")
                .HasValue<ModificareValoareEntity>("ModificareValoare")
                .HasValue<PrelungireContractEntity>("PrelungireContract")
                .HasValue<ModificareLivrabileEntity>("ModificareLivrabile");

            // One-to-many relationships
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
            modelBuilder.Entity<TaskProiectEntity>()
                .HasOne(t => t.Responsabil)
                .WithMany() // No inverse navigation property
                .HasForeignKey(t => t.ResponsabilId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}