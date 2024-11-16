using System;
using System.Collections.Generic;
using Koi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Entities;

public partial class KoifarmContext : DbContext
{
    public KoifarmContext()
    {
    }

    public KoifarmContext(DbContextOptions<KoifarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CaKoi> CaKois { get; set; }

    public virtual DbSet<DanhGia> DanhGia { get; set; }

    public virtual DbSet<GioHangCuaToi> GioHangCuaTois { get; set; }

    public virtual DbSet<KyGui> KyGuis { get; set; }

    public virtual DbSet<LichSuKyGui> LichSuKyGuis { get; set; }

    public virtual DbSet<LichSuMuaHang> LichSuMuaHangs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

    => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=KoiStore10;Persist Security Info=True;User ID=sa;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CaKoi>(entity =>
        {
            entity.HasKey(e => e.CaKoiId).HasName("PK__CaKoi__F8555EAAD755BE4F");

            entity.ToTable("CaKoi");

            entity.Property(e => e.CaKoiId).HasColumnName("CaKoiID");
            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Giong).HasMaxLength(50);
            entity.Property(e => e.KichThuoc).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.NguonGoc).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<DanhGia>(entity =>
        {
            entity.HasKey(e => e.DanhGiaId).HasName("PK__DanhGia__52C0CA25EED770E8");

            entity.Property(e => e.DanhGiaId).HasColumnName("DanhGiaID");
            entity.Property(e => e.CaKoiId).HasColumnName("CaKoiID");
            entity.Property(e => e.NoiDung).HasMaxLength(255);

            entity.HasOne(d => d.CaKoi).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.CaKoiId)
                .HasConstraintName("FK__DanhGia__CaKoiID__3A81B327");
        });

        modelBuilder.Entity<GioHangCuaToi>(entity =>
        {
            entity.HasKey(e => e.GioHangId).HasName("PK__GioHangC__4242280DE7F437D3");

            entity.ToTable("GioHangCuaToi");

            entity.Property(e => e.GioHangId).HasColumnName("GioHangID");
            entity.Property(e => e.CaKoiId).HasColumnName("CaKoiID");

            entity.HasOne(d => d.CaKoi).WithMany(p => p.GioHangCuaTois)
                .HasForeignKey(d => d.CaKoiId)
                .HasConstraintName("FK__GioHangCu__CaKoi__3E52440B");
        });

        modelBuilder.Entity<KyGui>(entity =>
        {
            entity.HasKey(e => e.KyGuiId).HasName("PK__KyGui__1B9A075CC0D288AA");

            entity.ToTable("KyGui");

            entity.Property(e => e.KyGuiId)
                .ValueGeneratedOnAdd()
                .HasColumnName("KyGuiID");
            entity.Property(e => e.ChuanLoai).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.LuongThucAnNgay).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.NgayKyGui).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguonGoc).HasMaxLength(100);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);
            entity.Property(e => e.TinhCach).HasMaxLength(255);
            entity.Property(e => e.UrlhinhAnh)
                .HasMaxLength(255)
                .HasColumnName("URLHinhAnh");

            entity.HasOne(d => d.KyGuiNavigation).WithOne(p => p.KyGui)
                .HasForeignKey<KyGui>(d => d.KyGuiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KyGui__KyGuiID__5441852A");
        });

        modelBuilder.Entity<LichSuKyGui>(entity =>
        {
            entity.HasKey(e => e.LichSuKyGuiId).HasName("PK__LichSuKy__BE47A48E8242A03C");

            entity.ToTable("LichSuKyGui");

            entity.Property(e => e.LichSuKyGuiId).HasColumnName("LichSuKyGuiID");
            entity.Property(e => e.KyGuiId).HasColumnName("KyGuiID");
            entity.Property(e => e.NgayXacNhan).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ThaoTac).HasMaxLength(255);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Ðang ký g?i");
        });

        modelBuilder.Entity<LichSuMuaHang>(entity =>
        {
            entity.HasKey(e => e.MuaHangId).HasName("PK__LichSuMu__C4CE6DA6C432650B");

            entity.ToTable("LichSuMuaHang");

            entity.Property(e => e.MuaHangId).HasColumnName("MuaHangID");
            entity.Property(e => e.NgayMua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

            entity.HasOne(d => d.SanPham).WithMany(p => p.LichSuMuaHangs)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__LichSuMua__SanPh__44FF419A");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.KhachHangId).HasName("PK__NguoiDun__880F211B1E5AE891");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__NguoiDung__UserI__4CA06362");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.SanPhamId).HasName("PK__SanPham__05180FF409D4B55D");

            entity.ToTable("SanPham");

            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");
            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Giong).HasMaxLength(50);
            entity.Property(e => e.KichThuoc).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.NguonGoc).HasMaxLength(50);
            entity.Property(e => e.TenSanPham).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F8F4DD551");

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572F21AA140").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("guest")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly KoifarmContext _context;

        public SanPhamRepository(KoifarmContext context)
        {
            _context = context;
        }

        // Lấy SanPham theo ID
        public async Task<SanPham> GetByIdAsync(int sanPhamID)
        {
            return await _context.SanPhams.FirstOrDefaultAsync(s => s.SanPhamId == sanPhamID);
        }

        // Lấy tất cả các SanPham
        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams.ToListAsync();
        }

        // Thêm một SanPham mới
        public async Task<SanPham> AddAsync(SanPham sanPham)
        {
            await _context.SanPhams.AddAsync(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }

        // Cập nhật một SanPham
        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            _context.SanPhams.Update(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }

        // Xóa SanPham theo ID
        public async Task<bool> DeleteAsync(int sanPhamID)
        {
            var sanPham = await GetByIdAsync(sanPhamID);
            if (sanPham == null)
            {
                return false;
            }

            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}