using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Entities;

public partial class CaKoiStoreContext : DbContext
{
    public CaKoiStoreContext()
    {
    }

    public CaKoiStoreContext(DbContextOptions<CaKoiStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consignment> Consignments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DashboardReport> DashboardReports { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CaKoi_Store;Persist Security Info=True;User ID=sa;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consignment>(entity =>
        {
            entity.HasKey(e => e.ConsignmentId).HasName("PK__Consignm__EAEBA9A377D6F9C1");

            entity.ToTable("Consignment");

            entity.Property(e => e.ConsignmentId).HasColumnName("Consignment_id");
            entity.Property(e => e.ConsignmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Consignment_date");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Consignme__Custo__4CA06362");

            entity.HasOne(d => d.Koi).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__Consignme__Koi_i__4D94879B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB382B102A8EFAA");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534624A0D32").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DashboardReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Dashboar__30F9919916929CD8");

            entity.ToTable("Dashboard_Reports");

            entity.Property(e => e.ReportId).HasColumnName("Report_id");
            entity.Property(e => e.ReportDate)
                .HasColumnType("datetime")
                .HasColumnName("Report_date");
            entity.Property(e => e.TotalCustomers).HasColumnName("Total_customers");
            entity.Property(e => e.TotalKoiSold).HasColumnName("Total_koi_sold");
            entity.Property(e => e.TotalSales)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_sales");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PK__FAQs__838050BC6F6E83C8");

            entity.ToTable("FAQs");

            entity.Property(e => e.FaqId).HasColumnName("FAQ_id");
            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.Question).HasColumnType("text");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__CDC95E704180E36B");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("Feedback_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.FeedbackText)
                .HasColumnType("text")
                .HasColumnName("Feedback_text");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Response).HasColumnType("text");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__Custom__47DBAE45");

            entity.HasOne(d => d.Koi).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__Feedback__Koi_id__48CFD27E");
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__008892D9DF13E045");

            entity.ToTable("Koi");

            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FoodPerDay)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Food_per_day");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Personality).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ScreeningRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Screening_rate");
            entity.Property(e => e.Size).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Managers__ADA093659759896B");

            entity.HasIndex(e => e.Email, "UQ__Managers__A9D10534243D30E2").IsUnique();

            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("Hire_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1FF845392295DCA");

            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_amount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__3E52440B");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Order_De__92B53CC733E188F2");

            entity.ToTable("Order_Details");

            entity.Property(e => e.OrderDetailId).HasColumnName("Order_detail_id");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Koi).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__Order_Det__Koi_i__4222D4EF");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Order_Det__Order__412EB0B6");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__DAF28E93D963B456");

            entity.Property(e => e.PromotionId).HasColumnName("Promotion_id");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Discount_percentage");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_date");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__32D2E85B1E5CD0DB");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D10534FDB0A0B6").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("Staff_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("Hire_date");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Manager).WithMany(p => p.Staff)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Staff__Manager_i__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
