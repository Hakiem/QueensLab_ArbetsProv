using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ArbetsUppdrag.Entities;

namespace ArbetsUppdrag.Migrations
{
    [DbContext(typeof(LocationsDbContext))]
    partial class LocationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArbetsUppdrag.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<string>("LocationCountry")
                        .HasMaxLength(50);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Longitude");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });
        }
    }
}
