namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucLoaiHinhController : BaseController<DanhMucLoaiHinh, IDanhMucLoaiHinhService>
    {
        private readonly IDanhMucLoaiHinhService _DanhMucLoaiHinhService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucLoaiHinhController(IDanhMucLoaiHinhService DanhMucLoaiHinhService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucLoaiHinhService, WebHostEnvironment)
        {
            _DanhMucLoaiHinhService = DanhMucLoaiHinhService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

