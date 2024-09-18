namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThongBaoController : BaseController<ThongBao, IThongBaoService>
    {
    private readonly IThongBaoService _ThongBaoService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ThongBaoController(IThongBaoService ThongBaoService, IWebHostEnvironment WebHostEnvironment) : base(ThongBaoService, WebHostEnvironment)
    {
    _ThongBaoService = ThongBaoService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

