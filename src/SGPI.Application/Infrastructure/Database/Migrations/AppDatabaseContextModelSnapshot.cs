﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SGPI.Application.Infrastructure.Database;

#nullable disable

namespace SGPI.Application.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AppDatabaseContext))]
    partial class AppDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SGPI.Domain.Entities.FinancialProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_at");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean")
                        .HasColumnName("enabled");

                    b.Property<double>("InterestRate")
                        .HasColumnType("double precision")
                        .HasColumnName("interest_rate");

                    b.Property<DateTime>("MaturityDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("maturity_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("product_code");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("type");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_at");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("financial_products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
