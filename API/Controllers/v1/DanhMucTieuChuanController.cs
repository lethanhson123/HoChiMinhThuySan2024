namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucTieuChuanController : BaseController<DanhMucTieuChuan, IDanhMucTieuChuanService>
    {
    private readonly IDanhMucTieuChuanService _DanhMucTieuChuanService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public DanhMucTieuChuanController(IDanhMucTieuChuanService DanhMucTieuChuanService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucTieuChuanService, WebHostEnvironment)
    {
    _DanhMucTieuChuanService = DanhMucTieuChuanService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

