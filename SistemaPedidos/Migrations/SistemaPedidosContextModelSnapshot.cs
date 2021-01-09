﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPedidos.Data;

namespace SistemaPedidos.Migrations
{
    [DbContext(typeof(SistemaPedidosContext))]
    partial class SistemaPedidosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaPedidos.Models.Bebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Bebida");
                });

            modelBuilder.Entity("SistemaPedidos.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BebidaId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Mesa");

                    b.Property<string>("NomeDoSolicitante");

                    b.Property<int>("PratoId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BebidaId");

                    b.HasIndex("PratoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("SistemaPedidos.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("SistemaPedidos.Models.Pedido", b =>
                {
                    b.HasOne("SistemaPedidos.Models.Bebida", "Bebida")
                        .WithMany()
                        .HasForeignKey("BebidaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaPedidos.Models.Prato", "Prato")
                        .WithMany()
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
