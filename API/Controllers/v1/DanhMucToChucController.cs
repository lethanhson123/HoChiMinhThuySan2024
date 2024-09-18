namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucToChucController : BaseController<DanhMucToChuc, IDanhMucToChucService>
    {
        private readonly IDanhMucToChucService _DanhMucToChucService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucToChucController(IDanhMucToChucService DanhMucToChucService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucToChucService, WebHostEnvironment)
        {
            _DanhMucToChucService = DanhMucToChucService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

