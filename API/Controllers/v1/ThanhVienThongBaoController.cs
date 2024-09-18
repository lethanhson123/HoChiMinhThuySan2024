namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThanhVienThongBaoController : BaseController<ThanhVienThongBao, IThanhVienThongBaoService>
    {
    private readonly IThanhVienThongBaoService _ThanhVienThongBaoService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ThanhVienThongBaoController(IThanhVienThongBaoService ThanhVienThongBaoService, IWebHostEnvironment WebHostEnvironment) : base(ThanhVienThongBaoService, WebHostEnvironment)
    {
    _ThanhVienThongBaoService = ThanhVienThongBaoService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

