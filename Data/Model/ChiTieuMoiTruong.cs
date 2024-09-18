namespace Data.Model
{
    public partial class ChiTieuMoiTruong : BaseModel
    {
        public DateTime? NgayGhiNhan { get; set; }
        public long? ToChucID { get; set; }
        public string? ToChucName { get; set; }
        public long? DanhMucChiTieuMoiTruongID { get; set; }
        public string? DanhMucChiTieuMoiTruongName { get; set; }
        public decimal? SoLieu { get; set; }
        public decimal? NguongThap { get; set; }
        public decimal? NguongCao { get; set; }

        public ChiTieuMoiTruong()
        {
            NgayGhiNhan = GlobalHelper.InitializationDateTime;
        }
    }
}

