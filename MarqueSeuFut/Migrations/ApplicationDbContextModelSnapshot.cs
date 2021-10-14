﻿// <auto-generated />
using MarqueSeuFut.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarqueSeuFut.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarqueSeuFut.Models.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PosicaoId")
                        .HasColumnType("int");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PosicaoId");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("MarqueSeuFut.Models.Posicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posicoes");
                });

            modelBuilder.Entity("MarqueSeuFut.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoFundacao")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("MarqueSeuFut.Models.Jogador", b =>
                {
                    b.HasOne("MarqueSeuFut.Models.Posicao", "Posicao")
                        .WithMany("Jogadores")
                        .HasForeignKey("PosicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarqueSeuFut.Models.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posicao");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("MarqueSeuFut.Models.Posicao", b =>
                {
                    b.Navigation("Jogadores");
                });

            modelBuilder.Entity("MarqueSeuFut.Models.Time", b =>
                {
                    b.Navigation("Jogadores");
                });
#pragma warning restore 612, 618
        }
    }
}
