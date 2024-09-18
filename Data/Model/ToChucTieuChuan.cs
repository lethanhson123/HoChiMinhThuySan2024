namespace Data.Model
{
    public partial class ToChucTieuChuan : BaseModel
    {
        public long? DanhMucTieuChuanID { get; set; }
        public string? DanhMucTieuChuanName { get; set; }
        public int? NamGhiNhan { get; set; }
        public ToChucTieuChuan()
        {
        }
    }
}

