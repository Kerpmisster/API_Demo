using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_DEMO.Models;

public partial class ApiDemoContext : DbContext
{
    public ApiDemoContext()
    {
    }

    public ApiDemoContext(DbContextOptions<ApiDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SSHUBNQA\\SQLEXPRESS;Database=API_demo;User ID=sa;Password=123456;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId);

            entity.Property(e => e.OrdersId).HasColumnName("Orders_Id");
            entity.Property(e => e.AccountCode).HasColumnName("Account_Code");
            entity.Property(e => e.PaymentMethods).HasColumnName("Payment_Methods");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrdersDetail>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.OrdersId, e.SpId });

            entity.ToTable("OrdersDetail");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OrdersId).HasColumnName("Orders_Id");
            entity.Property(e => e.SpId).HasColumnName("SP_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("Total_Amount");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersDetail_Orders");

            entity.HasOne(d => d.Sp).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.SpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersDetail_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.SpId);

            entity.Property(e => e.SpId).HasColumnName("SP_Id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Category");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.AvatarImg)
                .IsUnicode(false)
                .HasColumnName("Avatar_img");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Users_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
