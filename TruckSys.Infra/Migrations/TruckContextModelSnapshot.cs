﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckSys.Infra.Data;

#nullable disable

namespace TruckSys.Infra.Migrations
{
    [DbContext(typeof(TruckContext))]
    partial class TruckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TruckSys.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int")
                        .HasColumnName("AnoFabricacao");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int")
                        .HasColumnName("AnoModelo");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("Modelo");

                    b.HasKey("Id");

                    b.ToTable("Trucks", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
