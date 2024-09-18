namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucChiTieuMoiTruongController : BaseController<DanhMucChiTieuMoiTruong, IDanhMucChiTieuMoiTruongService>
    {
        private readonly IDanhMucChiTieuMoiTruongService _DanhMucChiTieuMoiTruongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucChiTieuMoiTruongController(IDanhMucChiTieuMoiTruongService DanhMucChiTieuMoiTruongService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucChiTieuMoiTruongService, WebHostEnvironment)
        {
            _DanhMucChiTieuMoiTruongService = DanhMucChiTieuMoiTruongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

