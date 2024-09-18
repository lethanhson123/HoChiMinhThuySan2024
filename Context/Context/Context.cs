
namespace Data.Context
{
	public partial class Context : DbContext
	{
		public Context()
		{
		}
		public Context(DbContextOptions<Context> options)
			: base(options)
		{
		}
        public virtual DbSet<Data.Model.ChiTieuMoiTruong> ChiTieuMoiTruong { get; set; }

        public virtual DbSet<Data.Model.DanhMucAPI> DanhMucAPI { get; set; }
        public virtual DbSet<Data.Model.DanhMucChucNang> DanhMucChucNang { get; set; }
        public virtual DbSet<Data.Model.DanhMucGiong> DanhMucGiong { get; set; }
        public virtual DbSet<Data.Model.DanhMucHieuMay> DanhMucHieuMay { get; set; }
        public virtual DbSet<Data.Model.DanhMucLoaiGiong> DanhMucLoaiGiong { get; set; }
        public virtual DbSet<Data.Model.DanhMucNganhNghe> DanhMucNganhNghe { get; set; }
        public virtual DbSet<Data.Model.DanhMucNgonNgu> DanhMucNgonNgu { get; set; }       
        public virtual DbSet<Data.Model.DanhMucQuanHuyen> DanhMucQuanHuyen { get; set; }
        public virtual DbSet<Data.Model.DanhMucQuocGia> DanhMucQuocGia { get; set; }
        public virtual DbSet<Data.Model.DanhMucThanhVien> DanhMucThanhVien { get; set; }
        public virtual DbSet<Data.Model.DanhMucTinhThanh> DanhMucTinhThanh { get; set; }
        public virtual DbSet<Data.Model.DanhMucTinhThanhToaDo> DanhMucTinhThanhToaDo { get; set; }
        public virtual DbSet<Data.Model.DanhMucToChuc> DanhMucToChuc { get; set; }
        public virtual DbSet<Data.Model.DanhMucXaPhuong> DanhMucXaPhuong { get; set; }
        public virtual DbSet<Data.Model.DanhMucTieuChuan> DanhMucTieuChuan { get; set; }
        public virtual DbSet<Data.Model.DanhMucLoaiHinh> DanhMucLoaiHinh { get; set; }
        public virtual DbSet<Data.Model.DanhMucCuaHang> DanhMucCuaHang { get; set; }
        public virtual DbSet<Data.Model.DanhMucNguyenVatLieu> DanhMucNguyenVatLieu { get; set; }
        public virtual DbSet<Data.Model.DanhMucChiTieuMoiTruong> DanhMucChiTieuMoiTruong { get; set; }

        public virtual DbSet<Data.Model.ThanhVien> ThanhVien { get; set; }
        public virtual DbSet<Data.Model.ThanhVienChucNang> ThanhVienChucNang { get; set; }
        public virtual DbSet<Data.Model.ThanhVienLichSuTruyCap> ThanhVienLichSuTruyCap { get; set; }
        public virtual DbSet<Data.Model.ThanhVienThongBao> ThanhVienThongBao { get; set; }
        public virtual DbSet<Data.Model.ThanhVienToken> ThanhVienToken { get; set; }

        public virtual DbSet<Data.Model.ThongBao> ThongBao { get; set; }
        public virtual DbSet<Data.Model.ThongBaoThanhVien> ThongBaoThanhVien { get; set; }

        public virtual DbSet<Data.Model.ToChuc> ToChuc { get; set; }
        public virtual DbSet<Data.Model.ToChucQuanLy> ToChucQuanLy { get; set; }
        public virtual DbSet<Data.Model.ToChucTapTinDinhKem> ToChucTapTinDinhKem { get; set; }
        public virtual DbSet<Data.Model.ToChucToaDo> ToChucToaDo { get; set; }
        public virtual DbSet<Data.Model.ToChucLongBe> ToChucLongBe { get; set; }
        public virtual DbSet<Data.Model.ToChucNuoiNhuyenThe> ToChucNuoiNhuyenThe { get; set; }
        public virtual DbSet<Data.Model.ToChucPhuongTienKhaiThac> ToChucPhuongTienKhaiThac { get; set; }
        public virtual DbSet<Data.Model.ToChucVungNuoi> ToChucVungNuoi { get; set; }
        public virtual DbSet<Data.Model.ToChucGiong> ToChucGiong { get; set; }
        public virtual DbSet<Data.Model.ToChucTieuChuan> ToChucTieuChuan { get; set; }
        public virtual DbSet<Data.Model.ToChucNguyenVatLieu> ToChucNguyenVatLieu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(GlobalHelper.SQLServerConectionString);
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			OnModelCreatingPartial(modelBuilder);
		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
