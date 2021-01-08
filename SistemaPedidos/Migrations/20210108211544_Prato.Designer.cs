﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPedidos.Data;

namespace SistemaPedidos.Migrations
{
    [DbContext(typeof(SistemaPedidosContext))]
    [Migration("20210108211544_Prato")]
    partial class Prato
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaPedidos.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bebida");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Mesa");

                    b.Property<string>("NomeDoSolicitante");

                    b.Property<string>("Prato");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("SistemaPedidos.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("cardapio");
                });
#pragma warning restore 612, 618
        }
    }
}