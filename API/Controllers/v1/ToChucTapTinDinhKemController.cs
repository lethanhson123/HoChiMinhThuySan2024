namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucTapTinDinhKemController : BaseController<ToChucTapTinDinhKem, IToChucTapTinDinhKemService>
    {
    private readonly IToChucTapTinDinhKemService _ToChucTapTinDinhKemService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ToChucTapTinDinhKemController(IToChucTapTinDinhKemService ToChucTapTinDinhKemService, IWebHostEnvironment WebHostEnvironment) : base(ToChucTapTinDinhKemService, WebHostEnvironment)
    {
    _ToChucTapTinDinhKemService = ToChucTapTinDinhKemService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

