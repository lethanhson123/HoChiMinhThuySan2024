namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucThanhVienController : BaseController<DanhMucThanhVien, IDanhMucThanhVienService>
    {
        private readonly IDanhMucThanhVienService _DanhMucThanhVienService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucThanhVienController(IDanhMucThanhVienService DanhMucThanhVienService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucThanhVienService, WebHostEnvironment)
        {
            _DanhMucThanhVienService = DanhMucThanhVienService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

