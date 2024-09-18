namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucNganhNgheController : BaseController<DanhMucNganhNghe, IDanhMucNganhNgheService>
    {
        private readonly IDanhMucNganhNgheService _DanhMucNganhNgheService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucNganhNgheController(IDanhMucNganhNgheService DanhMucNganhNgheService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucNganhNgheService, WebHostEnvironment)
        {
            _DanhMucNganhNgheService = DanhMucNganhNgheService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

