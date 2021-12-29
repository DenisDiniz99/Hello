﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Migrations
{
    [DbContext(typeof(SysContext))]
    partial class SysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloAssunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AssuntoAtendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Atendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssuntoAtendimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssuntoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CidadaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColaboradorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("int");

                    b.Property<int>("TipoAtendimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoAtendimentoId");

                    b.HasIndex("CidadaoId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SrtorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataCad")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TelefoneFixo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Cidadaos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Colaborador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCad")
                        .HasColumnType("datetime2");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Setor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloSetor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Atendimento", b =>
                {
                    b.HasOne("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", "AssuntoAtendimento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("AssuntoAtendimentoId");

                    b.HasOne("Prefeitura.SysCras.Business.Entities.Cidadao", "Cidadao")
                        .WithMany("Atendimentos")
                        .HasForeignKey("CidadaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prefeitura.SysCras.Business.Entities.Colaborador", "Colaborador")
                        .WithMany("Atendimentos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Prefeitura.SysCras.Business.ValueObjects.Protocolo", "Protocolo", b1 =>
                        {
                            b1.Property<Guid>("AtendimentoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumProtocolo")
                                .HasColumnType("int");

                            b1.HasKey("AtendimentoId");

                            b1.ToTable("Atendimentos");

                            b1.WithOwner()
                                .HasForeignKey("AtendimentoId");
                        });

                    b.Navigation("AssuntoAtendimento");

                    b.Navigation("Cidadao");

                    b.Navigation("Colaborador");

                    b.Navigation("Protocolo");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cargo", b =>
                {
                    b.HasOne("Prefeitura.SysCras.Business.Entities.Setor", "Setor")
                        .WithMany("Cargos")
                        .HasForeignKey("SetorId");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.OwnsOne("Prefeitura.SysCras.Business.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("CidadaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CidadaoId");

                            b1.ToTable("Cidadaos");

                            b1.WithOwner()
                                .HasForeignKey("CidadaoId");
                        });

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Colaborador", b =>
                {
                    b.HasOne("Prefeitura.SysCras.Business.Entities.Cargo", "Cargo")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Setor", b =>
                {
                    b.OwnsOne("Prefeitura.SysCras.Business.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("SetorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SetorId");

                            b1.ToTable("Setores");

                            b1.WithOwner()
                                .HasForeignKey("SetorId");
                        });

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cargo", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Colaborador", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Setor", b =>
                {
                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}
