namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucTinhThanhController : BaseController<DanhMucTinhThanh, IDanhMucTinhThanhService>
    {
    private readonly IDanhMucTinhThanhService _DanhMucTinhThanhService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public DanhMucTinhThanhController(IDanhMucTinhThanhService DanhMucTinhThanhService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucTinhThanhService, WebHostEnvironment)
    {
    _DanhMucTinhThanhService = DanhMucTinhThanhService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

