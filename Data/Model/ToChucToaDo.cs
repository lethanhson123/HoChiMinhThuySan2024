namespace Data.Model
{
    public partial class ToChucToaDo : BaseModel
    {
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public long? ToChucVungNuoiID { get; set; }
        public string? ToChucVungNuoiName { get; set; }
        public ToChucToaDo()
        {
        }
    }
}

