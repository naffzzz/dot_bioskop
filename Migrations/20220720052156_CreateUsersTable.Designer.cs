﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20220720052156_CreateUsersTable")]
    partial class CreateUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("dot_bioskop.Models.users", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("activation_key")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasColumnName("activation_key");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<int>("is_admin")
                        .HasColumnType("int")
                        .HasColumnName("is_admin");

                    b.Property<int>("is_confirmed")
                        .HasColumnType("bool")
                        .HasColumnName("is_confirmed");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
