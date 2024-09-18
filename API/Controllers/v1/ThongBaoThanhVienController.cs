namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThongBaoThanhVienController : BaseController<ThongBaoThanhVien, IThongBaoThanhVienService>
    {
    private readonly IThongBaoThanhVienService _ThongBaoThanhVienService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ThongBaoThanhVienController(IThongBaoThanhVienService ThongBaoThanhVienService, IWebHostEnvironment WebHostEnvironment) : base(ThongBaoThanhVienService, WebHostEnvironment)
    {
    _ThongBaoThanhVienService = ThongBaoThanhVienService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

