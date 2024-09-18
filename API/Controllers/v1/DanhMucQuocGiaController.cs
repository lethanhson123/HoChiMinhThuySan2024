namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucQuocGiaController : BaseController<DanhMucQuocGia, IDanhMucQuocGiaService>
    {
    private readonly IDanhMucQuocGiaService _DanhMucQuocGiaService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public DanhMucQuocGiaController(IDanhMucQuocGiaService DanhMucQuocGiaService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucQuocGiaService, WebHostEnvironment)
    {
    _DanhMucQuocGiaService = DanhMucQuocGiaService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

