﻿// <auto-generated />
using Linker.BusinessLogic.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Linker.BusinessLogic.Migrations
{
    [DbContext(typeof(LinkerContext))]
    [Migration("20241231135851_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Linker.BusinessLogic.Entities.Link", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<string>("Redirect")
                        .HasMaxLength(4096)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
