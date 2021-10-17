﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pubquizish.Game.Infrastructure.EntityFramework;

namespace api.Migrations.GameDb
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Pubquizish.Game.NewGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("_code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<DateTime>("_createdOn")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreatedOn");

                    b.Property<Guid>("_creatorId")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreatorId");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("NewGames");
                });
#pragma warning restore 612, 618
        }
    }
}
