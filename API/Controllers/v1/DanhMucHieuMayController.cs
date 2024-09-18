namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucHieuMayController : BaseController<DanhMucHieuMay, IDanhMucHieuMayService>
    {
        private readonly IDanhMucHieuMayService _DanhMucHieuMayService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucHieuMayController(IDanhMucHieuMayService DanhMucHieuMayService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucHieuMayService, WebHostEnvironment)
        {
            _DanhMucHieuMayService = DanhMucHieuMayService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

