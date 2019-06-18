﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherControlApp.Models;

namespace WeatherControlApp.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20190618121431_addWeathertoDB")]
    partial class addWeathertoDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherControlApp.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Humidity");

                    b.Property<int>("Temperature");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("WeatherItems");
                });
#pragma warning restore 612, 618
        }
    }
}