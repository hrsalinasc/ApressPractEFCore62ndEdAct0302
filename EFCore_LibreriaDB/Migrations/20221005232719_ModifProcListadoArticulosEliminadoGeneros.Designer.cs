﻿// <auto-generated />
using System;
using EFCore_LibreriaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    [DbContext(typeof(InventarioDbContext))]
    [Migration("20221005232719_ModifProcListadoArticulosEliminadoGeneros")]
    partial class ModifProcListadoArticulosEliminadoGeneros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArticulosParticipantes", b =>
                {
                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId", "ParticipanteId");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("ArticulosParticipantes");
                });

            modelBuilder.Entity("InventarioModelos.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("CreadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEnVenta")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<decimal?>("PrecioCompra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrecioFinalOActual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("InventarioModelos.ArticuloGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("ArticuloId", "GeneroId")
                        .IsUnique();

                    b.ToTable("ArticulosGeneros");
                });

            modelBuilder.Entity("InventarioModelos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("InventarioModelos.CategoriaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ColorNombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ColorValor")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaDetalles");
                });

            modelBuilder.Entity("InventarioModelos.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("InventarioModelos.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPorUsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("ArticulosParticipantes", b =>
                {
                    b.HasOne("InventarioModelos.Articulo", null)
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_ParticipanteArticulo_Articulos_ArticuloId");

                    b.HasOne("InventarioModelos.Participante", null)
                        .WithMany()
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ArticuloParticipante_Participantes_ParticipanteId");
                });

            modelBuilder.Entity("InventarioModelos.Articulo", b =>
                {
                    b.HasOne("InventarioModelos.Categoria", "Categoria")
                        .WithMany("Articulos")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("InventarioModelos.ArticuloGenero", b =>
                {
                    b.HasOne("InventarioModelos.Articulo", "Articulo")
                        .WithMany("ArticulosGeneros")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventarioModelos.Genero", "Genero")
                        .WithMany("ArticulosGeneros")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("InventarioModelos.CategoriaDetalle", b =>
                {
                    b.HasOne("InventarioModelos.Categoria", "Categoria")
                        .WithOne("CategoriaDetalle")
                        .HasForeignKey("InventarioModelos.CategoriaDetalle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("InventarioModelos.Articulo", b =>
                {
                    b.Navigation("ArticulosGeneros");
                });

            modelBuilder.Entity("InventarioModelos.Categoria", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("CategoriaDetalle");
                });

            modelBuilder.Entity("InventarioModelos.Genero", b =>
                {
                    b.Navigation("ArticulosGeneros");
                });
#pragma warning restore 612, 618
        }
    }
}
