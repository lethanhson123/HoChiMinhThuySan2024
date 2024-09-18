namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucLoaiGiongController : BaseController<DanhMucLoaiGiong, IDanhMucLoaiGiongService>
    {
        private readonly IDanhMucLoaiGiongService _DanhMucLoaiGiongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucLoaiGiongController(IDanhMucLoaiGiongService DanhMucLoaiGiongService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucLoaiGiongService, WebHostEnvironment)
        {
            _DanhMucLoaiGiongService = DanhMucLoaiGiongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

