namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucNuoiNhuyenTheController : BaseController<ToChucNuoiNhuyenThe, IToChucNuoiNhuyenTheService>
    {
    private readonly IToChucNuoiNhuyenTheService _ToChucNuoiNhuyenTheService;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public ToChucNuoiNhuyenTheController(IToChucNuoiNhuyenTheService ToChucNuoiNhuyenTheService, IWebHostEnvironment WebHostEnvironment) : base(ToChucNuoiNhuyenTheService, WebHostEnvironment)
    {
    _ToChucNuoiNhuyenTheService = ToChucNuoiNhuyenTheService;
    _WebHostEnvironment = WebHostEnvironment;
    }
    }
    }

