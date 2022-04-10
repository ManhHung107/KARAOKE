using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KARAOKE.Models.EF
{
    public partial class KaraokeDbContext : DbContext
    {
        public KaraokeDbContext()
            : base("name=KaraokeDbContext1")
        {
        }

        public virtual DbSet<CauHinh> CauHinh { get; set; }
        public virtual DbSet<ChiTietHoaDonBanHang> ChiTietHoaDonBanHang { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
        public virtual DbSet<DonViTinh> DonViTinh { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhong { get; set; }
        public virtual DbSet<MatHang> MatHang { get; set; }
        public virtual DbSet<NCC> NCC { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHinh>()
                .Property(e => e.tukhoa)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.MatHang)
                .WithOptional(e => e.DonViTinh)
                .HasForeignKey(e => e.IDDVT);

            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .HasMany(e => e.ChiTietHoaDonBanHang)
                .WithRequired(e => e.HoaDonBanHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NhanVienNhap)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .HasMany(e => e.ChiTietHoaDonNhap)
                .WithRequired(e => e.HoaDonNhap)
                .HasForeignKey(e => e.IDHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.Phong)
                .WithOptional(e => e.LoaiPhong)
                .HasForeignKey(e => e.IDLoaiPhong);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietHoaDonBanHang)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.IDMatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietHoaDonNhap)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.IDMatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NCC>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NCC>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NCC>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<NCC>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<NCC>()
                .HasMany(e => e.HoaDonNhap)
                .WithOptional(e => e.NCC)
                .HasForeignKey(e => e.IDNhaCC);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.NguoiCapNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonBanHang)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.IDNguoiBan);

            modelBuilder.Entity<Phong>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.HoaDonBanHang)
                .WithRequired(e => e.Phong)
                .HasForeignKey(e => e.IDPhong)
                .WillCascadeOnDelete(false);
        }
    }
}
