﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherControlApp.Models;

namespace WeatherControlApp.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20190619220414_locationfk")]
    partial class locationfk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherControlApp.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WeatherControlApp.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Humidity");

                    b.Property<int?>("LocationId");

                    b.Property<int>("Temperature");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TypeId");

                    b.ToTable("WeatherItems");
                });

            modelBuilder.Entity("WeatherControlApp.Models.WeatherType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clouds");

                    b.Property<string>("Fog");

                    b.Property<string>("Rain");

                    b.Property<string>("Storm");

                    b.Property<string>("Sun");

                    b.Property<string>("Windy");

                    b.HasKey("Id");

                    b.ToTable("WeatherType");
                });

            modelBuilder.Entity("WeatherControlApp.Models.Weather", b =>
                {
                    b.HasOne("WeatherControlApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("WeatherControlApp.Models.WeatherType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
