﻿// <auto-generated />
using System;
using APIStuff.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIStuff.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIStuff.Models.ActionHeroes", b =>
                {
                    b.Property<int>("ActionHeroesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("epicMovies")
                        .HasColumnType("int");

                    b.Property<string>("heroName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionHeroesID");

                    b.ToTable("ActionHeroes");
                });

            modelBuilder.Entity("APIStuff.Models.Battle", b =>
                {
                    b.Property<int>("battleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("battleId");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("APIStuff.Models.Samurai", b =>
                {
                    b.Property<int>("samuraiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("battlesFought")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("samuraiID");

                    b.ToTable("Samurai");
                });

            modelBuilder.Entity("APIStuff.Models.SamuraisInBattle", b =>
                {
                    b.Property<int>("samuraiId")
                        .HasColumnType("int");

                    b.Property<int>("battleId")
                        .HasColumnType("int");

                    b.HasKey("samuraiId", "battleId");

                    b.HasIndex("battleId");

                    b.ToTable("SamuraisInBattle");
                });

            modelBuilder.Entity("APIStuff.Models.SamuraisInBattle", b =>
                {
                    b.HasOne("APIStuff.Models.Battle", "battle")
                        .WithMany("SamuraisInBattle")
                        .HasForeignKey("battleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIStuff.Models.Samurai", "samurai")
                        .WithMany()
                        .HasForeignKey("samuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
