﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicoYPlaca.Infraestructure;

#nullable disable

namespace PicoYPlaca.Infraestructure.Migrations
{
    [DbContext(typeof(PicoYPlacaDbContext))]
    [Migration("20230822232936_CirculationResultIdChange")]
    partial class CirculationResultIdChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PicoYPlaca.Domain.CirculationResult", b =>
                {
                    b.Property<bool>("CanCirculate")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CirculationResults");
                });
#pragma warning restore 612, 618
        }
    }
}
