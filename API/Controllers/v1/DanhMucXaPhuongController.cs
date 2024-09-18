namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucXaPhuongController : BaseController<DanhMucXaPhuong, IDanhMucXaPhuongService>
    {
    private readonly IDanhMucXaPhuongService _DanhMucXaPhuongService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public DanhMucXaPhuongController(IDanhMucXaPhuongService DanhMucXaPhuongService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucXaPhuongService, WebHostEnvironment)
    {
    _DanhMucXaPhuongService = DanhMucXaPhuongService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

