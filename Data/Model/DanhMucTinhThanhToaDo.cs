namespace Data.Model
{
    public partial class DanhMucTinhThanhToaDo : BaseModel
    {
      
public long? DanhMucTinhThanhID { get; set; }
public long? DanhMucQuanHuyenID { get; set; }
public long? DanhMucXaPhuongID { get; set; }
public string? DanhMucTinhThanhName { get; set; }
public string? DanhMucQuanHuyenName { get; set; }
public string? DanhMucXaPhuongName { get; set; }
public string? KinhDo { get; set; }
public string? ViDo { get; set; }

        public DanhMucTinhThanhToaDo()
        {
        }
    }
}

