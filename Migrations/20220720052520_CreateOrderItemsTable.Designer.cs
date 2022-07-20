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
    [Migration("20220720052520_CreateOrderItemsTable")]
    partial class CreateOrderItemsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("dot_bioskop.Models.movie_schedules", b =>
                {
                    b.Property<long>("id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("end_time")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("end_time");

                    b.Property<long>("movie_id")
                        .HasColumnType("bigint")
                        .HasColumnName("movie_id");

                    b.Property<double>("price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("start_time")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("start_time");

                    b.Property<long>("studio_id")
                        .HasColumnType("bigint")
                        .HasColumnName("studio_id");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.ToTable("movie_schedules");
                });

            modelBuilder.Entity("dot_bioskop.Models.movies", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("overview")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("overview");

                    b.Property<DateTime>("play_until")
                        .HasColumnType("datetime")
                        .HasColumnName("play_until");

                    b.Property<string>("poster")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("poster");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("dot_bioskop.Models.order_items", b =>
                {
                    b.Property<long>("id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<long>("movie_schedule_id")
                        .HasColumnType("bigint")
                        .HasColumnName("movie_schedule_id");

                    b.Property<long>("order_id")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<double>("price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<int>("qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<double>("sub_total_price")
                        .HasColumnType("double")
                        .HasColumnName("sub_total_price");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.ToTable("order_items");
                });

            modelBuilder.Entity("dot_bioskop.Models.orders", b =>
                {
                    b.Property<long>("id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<int>("payment_method")
                        .HasColumnType("int")
                        .HasColumnName("payment_method");

                    b.Property<double>("total_item_price")
                        .HasColumnType("double")
                        .HasColumnName("total_item_price");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("dot_bioskop.Models.studios", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<long>("seat_capacity")
                        .HasColumnType("bigint")
                        .HasColumnName("seat_capacity");

                    b.Property<long>("studio_number")
                        .HasColumnType("bigint")
                        .HasColumnName("studio_number");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.ToTable("studios");
                });

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

            modelBuilder.Entity("dot_bioskop.Models.movie_schedules", b =>
                {
                    b.HasOne("dot_bioskop.Models.movies", "movie")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dot_bioskop.Models.studios", "studio")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");

                    b.Navigation("studio");
                });

            modelBuilder.Entity("dot_bioskop.Models.order_items", b =>
                {
                    b.HasOne("dot_bioskop.Models.movie_schedules", "movie_schedule")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dot_bioskop.Models.orders", "order")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie_schedule");

                    b.Navigation("order");
                });

            modelBuilder.Entity("dot_bioskop.Models.orders", b =>
                {
                    b.HasOne("dot_bioskop.Models.users", "user")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
