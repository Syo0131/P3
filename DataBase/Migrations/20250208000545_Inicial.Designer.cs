﻿// <auto-generated />
using System;
using DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(ItlaTvContext))]
    [Migration("20250208000545_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Entities.Generos.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenero"));

                    b.Property<string>("NombreGenero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdGenero");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("DataBase.Entities.Productoras.Productora", b =>
                {
                    b.Property<int>("IdProductora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProductora"));

                    b.Property<string>("NombreProductora")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdProductora");

                    b.HasIndex("NombreProductora")
                        .IsUnique();

                    b.ToTable("Productoras", (string)null);
                });

            modelBuilder.Entity("DataBase.Entities.Series.Serie", b =>
                {
                    b.Property<int>("IdSerie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSerie"));

                    b.Property<int>("IdGeneroPrimario")
                        .HasColumnType("int");

                    b.Property<int?>("IdGeneroSecundario")
                        .HasColumnType("int");

                    b.Property<int>("IdProductora")
                        .HasColumnType("int");

                    b.Property<string>("PortadaUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VideoURl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdSerie");

                    b.HasIndex("IdGeneroPrimario");

                    b.HasIndex("IdGeneroSecundario");

                    b.HasIndex("IdProductora");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("DataBase.Entities.Series.Serie", b =>
                {
                    b.HasOne("DataBase.Entities.Generos.Genero", "GeneroPrimario")
                        .WithMany("Series")
                        .HasForeignKey("IdGeneroPrimario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.Generos.Genero", "GeneroSecundario")
                        .WithMany()
                        .HasForeignKey("IdGeneroSecundario")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataBase.Entities.Productoras.Productora", "Productora")
                        .WithMany("Series")
                        .HasForeignKey("IdProductora")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GeneroPrimario");

                    b.Navigation("GeneroSecundario");

                    b.Navigation("Productora");
                });

            modelBuilder.Entity("DataBase.Entities.Generos.Genero", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("DataBase.Entities.Productoras.Productora", b =>
                {
                    b.Navigation("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
