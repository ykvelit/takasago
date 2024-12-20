﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Takasago.Data;

#nullable disable

namespace Takasago.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Takasago.Domain.UserPreference", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Key");

                    b.Property<string>("Preference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Preference");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Key");

                    b.HasIndex("UserId");

                    b.ToTable("UserPreferences", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
