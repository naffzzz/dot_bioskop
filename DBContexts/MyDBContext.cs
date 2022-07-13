using dot_bioskop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<users> users { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<studios> studios { get; set; }
        public DbSet<movie_schedules> movie_schedules { get; set; }
        public DbSet<order_items> order_items { get; set; }
        public DbSet<tags> tags { get; set; }
        public DbSet<movie_tags> movie_tags { get; set; }
        public DbSet<movies> movies { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<users>().ToTable("users");
            modelBuilder.Entity<orders>().ToTable("orders");
            modelBuilder.Entity<studios>().ToTable("studios");
            modelBuilder.Entity<movie_schedules>().ToTable("movie_schedules");
            modelBuilder.Entity<order_items>().ToTable("order_items");
            modelBuilder.Entity<tags>().ToTable("tags");
            modelBuilder.Entity<movie_tags>().ToTable("movie_tags");
            modelBuilder.Entity<movies>().ToTable("movies");

            // Configure Primary Keys  
            modelBuilder.Entity<users>().HasKey(u => u.id).HasName("PK_users");
            modelBuilder.Entity<orders>().HasKey(u => u.id).HasName("PK_orders");
            modelBuilder.Entity<studios>().HasKey(u => u.id).HasName("PK_studios");
            modelBuilder.Entity<movie_schedules>().HasKey(u => u.id).HasName("PK_movie_schedules");
            modelBuilder.Entity<order_items>().HasKey(u => u.id).HasName("PK_order_items");
            modelBuilder.Entity<tags>().HasKey(u => u.id).HasName("PK_tags");
            modelBuilder.Entity<movie_tags>().HasKey(u => u.id).HasName("PK_movie_tags");
            modelBuilder.Entity<movies>().HasKey(u => u.id).HasName("PK_movies");

            // Configure indexes  
            // modelBuilder.Entity<users>().HasIndex(u => u.name).HasDatabaseName("Idx_name");

            // Configure columns  
            modelBuilder.Entity<users>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<users>().Property(u => u.name).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.password).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.avatar).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.is_admin).HasColumnType("bool").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<users>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<users>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<orders>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<orders>().Property(u => u.user_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<orders>().Property(u => u.payment_method).HasColumnType("enum('0','1')").IsRequired();
            modelBuilder.Entity<orders>().Property(u => u.total_item_price).HasColumnType("double").IsRequired();
            modelBuilder.Entity<orders>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<orders>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<orders>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<studios>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<studios>().Property(u => u.studio_number).HasColumnType("int").IsRequired();
            modelBuilder.Entity<studios>().Property(u => u.seat_capacity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<studios>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<studios>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<studios>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<movie_schedules>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.movie_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.studio_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.start_time).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.end_time).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.price).HasColumnType("double").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.date).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<movie_schedules>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<movie_schedules>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<order_items>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.order_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.movie_schedule_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.qty).HasColumnType("int").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.price).HasColumnType("double").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.sub_total_price).HasColumnType("double").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<order_items>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<order_items>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<tags>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<tags>().Property(u => u.name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<tags>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<tags>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<tags>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<movie_tags>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<movie_tags>().Property(u => u.movie_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<movie_tags>().Property(u => u.tag_id).HasColumnType("bigint").IsRequired();
            modelBuilder.Entity<movie_tags>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<movie_tags>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<movie_tags>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<movies>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.title).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.overview).HasColumnType("text").IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.poster).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.play_until).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.created_at).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<movies>().Property(u => u.updated_at).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<movies>().Property(u => u.deleted_at).HasColumnType("datetime").IsRequired(false);

            // Configure relationships  
            modelBuilder.Entity<orders>().HasOne<users>().WithMany().HasPrincipalKey(u => u.id).HasForeignKey(o => o.user_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_orders_users");
            modelBuilder.Entity<order_items>().HasOne<orders>().WithMany().HasPrincipalKey(o => o.id).HasForeignKey(oi => oi.order_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_order_items_orders");
            modelBuilder.Entity<movie_schedules>().HasOne<studios>().WithMany().HasPrincipalKey(s => s.id).HasForeignKey(ms => ms.studio_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_movie_schedules_studios");
            modelBuilder.Entity<order_items>().HasOne<movie_schedules>().WithMany().HasPrincipalKey(ms => ms.id).HasForeignKey(oi => oi.movie_schedule_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_order_items_movie_schedules");
            modelBuilder.Entity<movie_schedules>().HasOne<movies>().WithMany().HasPrincipalKey(m => m.id).HasForeignKey(ms => ms.movie_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_movie_schedules_movies");
            modelBuilder.Entity<movie_tags>().HasOne<movies>().WithMany().HasPrincipalKey(m => m.id).HasForeignKey(mt => mt.movie_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_movie_tags_movies");
            modelBuilder.Entity<movie_tags>().HasOne<tags>().WithMany().HasPrincipalKey(t => t.id).HasForeignKey(mt => mt.tag_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_movie_tags_tags");
        }
    }
}