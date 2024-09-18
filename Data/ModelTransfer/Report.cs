namespace Data.Model
{
    public partial class Report : BaseModel
    {      
        public string? KinhDo { get; set; }
        public string? ViDo { get; set; }
        public long? DanhMucToChucID { get; set; }
        public string? DanhMucToChucName { get; set; }       
        public decimal? ThongKe001 { get; set; }       

        public Report()
        {
        }
    }
}

