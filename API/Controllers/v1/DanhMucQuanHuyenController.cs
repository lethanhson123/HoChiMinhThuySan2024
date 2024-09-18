namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucQuanHuyenController : BaseController<DanhMucQuanHuyen, IDanhMucQuanHuyenService>
    {
    private readonly IDanhMucQuanHuyenService _DanhMucQuanHuyenService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public DanhMucQuanHuyenController(IDanhMucQuanHuyenService DanhMucQuanHuyenService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucQuanHuyenService, WebHostEnvironment)
    {
    _DanhMucQuanHuyenService = DanhMucQuanHuyenService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

