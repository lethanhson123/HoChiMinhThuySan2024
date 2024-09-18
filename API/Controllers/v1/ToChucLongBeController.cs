namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucLongBeController : BaseController<ToChucLongBe, IToChucLongBeService>
    {
    private readonly IToChucLongBeService _ToChucLongBeService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ToChucLongBeController(IToChucLongBeService ToChucLongBeService, IWebHostEnvironment WebHostEnvironment) : base(ToChucLongBeService, WebHostEnvironment)
    {
    _ToChucLongBeService = ToChucLongBeService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

