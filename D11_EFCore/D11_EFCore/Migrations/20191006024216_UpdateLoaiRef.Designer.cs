﻿// <auto-generated />
using System;
using D11_EFCore.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace D11_EFCore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191006024216_UpdateLoaiRef")]
    partial class UpdateLoaiRef
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("D11_EFCore.DataModels.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh")
                        .HasMaxLength(150);

                    b.Property<int?>("MaLoaiCha");

                    b.Property<string>("MoTa");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(50);

                    b.HasKey("MaLoai");

                    b.HasIndex("MaLoaiCha");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("D11_EFCore.DataModels.Loai", b =>
                {
                    b.HasOne("D11_EFCore.DataModels.Loai", "LoaiCha")
                        .WithMany()
                        .HasForeignKey("MaLoaiCha");
                });
#pragma warning restore 612, 618
        }
    }
}
