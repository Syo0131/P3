using DataBase.Entities.Generos;
using DataBase.Entities.Productoras;
using DataBase.Entities.Series;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context
{
    public class ItlaTvContext : DbContext
    {
        #region "Constructor"
        public ItlaTvContext(DbContextOptions<ItlaTvContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        #endregion

        #region
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }
        public DbSet<Serie> Series { get; set; }
        #endregion




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            #endregion

            #region PrimaryKeys
            modelBuilder.Entity<Serie>().HasKey(serie => serie.IdSerie);
            modelBuilder.Entity<Productora>().HasKey(productora => productora.IdProductora);
            modelBuilder.Entity<Genero>().HasKey(genero => genero.IdGenero);
            #endregion

            #region Relaciones
            modelBuilder.Entity<Serie>()
            .HasOne(s => s.Productora)
            .WithMany(p => p.Series)
            .HasForeignKey(s => s.IdProductora)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
            .HasOne(s => s.GeneroPrimario)
            .WithMany(g => g.Series)
            .HasForeignKey(s => s.IdGeneroPrimario)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Serie>()
                .HasOne(s => s.GeneroSecundario)
                .WithMany()
                .HasForeignKey(s => s.IdGeneroSecundario)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Property Configurations
            modelBuilder.Entity<Serie>()
                .Property(s => s.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Serie>()
                .Property(s => s.PortadaUrl)
                .HasMaxLength(250);

            modelBuilder.Entity<Serie>()
                .Property(s => s.VideoURl)
                .HasMaxLength(250);

            modelBuilder.Entity<Productora>()
                .Property(p => p.NombreProductora)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Genero>()
                .Property(g => g.NombreGenero)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Productora>()
                .HasIndex(p => p.NombreProductora)
                .IsUnique();


            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
