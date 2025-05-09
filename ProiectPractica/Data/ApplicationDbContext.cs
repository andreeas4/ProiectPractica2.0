using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectPractica.Models;

namespace ProiectPractica.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        // Add profile data for application users by adding properties to the ApplicationUser class

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Proiect> Proiecte { get; set; }
        public DbSet<TaskProiect> Taskuri { get; set; }
        public DbSet<Subcontractor> Subcontractori { get; set; }
        public DbSet<ResponsabilProiect> ResponsabiliProiecte { get; set; }

        public DbSet<ActAditional> ActeAditionale { get; set; }
        public DbSet<PrelungireContract> PrelungiriContracte { get; set; }
        public DbSet<ModificareValoare> ModificariValoare { get; set; }
        public DbSet<ModificareLivrabile> ModificariLivrabile { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proiect>()
                .Property(p => p.ValoareContract)
                .HasPrecision(18, 2); // 18 cifre, 2 zecimale

            modelBuilder.Entity<ModificareValoare>()
                .Property(m => m.ValoareNoua)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ActAditional>()
                .HasDiscriminator<string>("TipAct") // va crea o coloană discriminator în tabel
                .HasValue<ModificareValoare>("ModificareValoare")
                .HasValue<PrelungireContract>("PrelungireContract")
                .HasValue<ModificareLivrabile>("ModificareLivrabile");

            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Responsabili)
                .WithOne(r => r.Proiect)
                .HasForeignKey(r => r.Cod)
                .OnDelete(DeleteBehavior.Cascade);

           

            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Livrabile)
                .WithOne(l => l.Proiect)
                .HasForeignKey(l => l.Cod)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Taskuri)
                .WithOne(t => t.Proiect)
                .HasForeignKey(t => t.Cod)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.ActeAditionale)
                .WithOne(a => a.Proiect)
                .HasForeignKey(a => a.Cod)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Livrabil> Livrabile { get; set; }

    }
}
