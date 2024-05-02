﻿// <auto-generated />
using System;
using API_Doceria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Doceria.Migrations
{
    [DbContext(typeof(DoceriaContext))]
    [Migration("20240501003925_CriacaoBancoComTabelas")]
    partial class CriacaoBancoComTabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_Doceria.Entities.Historico_Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("unidade");

                    b.Property<int>("ingredienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ingredienteId");

                    b.ToTable("historico_ingrediente");
                });

            modelBuilder.Entity("API_Doceria.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("unidade");

                    b.HasKey("Id");

                    b.ToTable("ingrediente");
                });

            modelBuilder.Entity("API_Doceria.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cliente");

                    b.Property<DateOnly>("DataPedido")
                        .HasColumnType("date")
                        .HasColumnName("dataPedido");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPedido")
                        .HasColumnType("money")
                        .HasColumnName("totalPedido");

                    b.HasKey("Id");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("API_Doceria.Entities.Pedido_Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.Property<decimal>("Total")
                        .HasColumnType("money")
                        .HasColumnName("total");

                    b.Property<int>("pedidoId")
                        .HasColumnType("integer");

                    b.Property<int>("receitaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("pedidoId");

                    b.HasIndex("receitaId");

                    b.ToTable("pedido_receita");
                });

            modelBuilder.Entity("API_Doceria.Entities.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money")
                        .HasColumnName("preco");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("money")
                        .HasColumnName("precoUnitario");

                    b.Property<int>("Rendimento")
                        .HasColumnType("integer")
                        .HasColumnName("rendimento");

                    b.Property<TimeOnly>("TempoDePreparo")
                        .HasColumnType("time without time zone")
                        .HasColumnName("tempoDePreparo");

                    b.HasKey("Id");

                    b.ToTable("receita");
                });

            modelBuilder.Entity("API_Doceria.Entities.Receita_Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ingredienteId")
                        .HasColumnType("integer");

                    b.Property<int>("receitaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ingredienteId");

                    b.HasIndex("receitaId");

                    b.ToTable("receita_ingrediente");
                });

            modelBuilder.Entity("API_Doceria.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("senha");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("tipoUsuario");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("API_Doceria.Entities.Historico_Ingrediente", b =>
                {
                    b.HasOne("API_Doceria.Entities.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("ingredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("API_Doceria.Entities.Pedido_Receita", b =>
                {
                    b.HasOne("API_Doceria.Entities.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Doceria.Entities.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("receitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("API_Doceria.Entities.Receita_Ingrediente", b =>
                {
                    b.HasOne("API_Doceria.Entities.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("ingredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Doceria.Entities.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("receitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Receita");
                });
#pragma warning restore 612, 618
        }
    }
}