namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucQuanLyController : BaseController<ToChucQuanLy, IToChucQuanLyService>
    {
        private readonly IToChucQuanLyService _ToChucQuanLyService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucQuanLyController(IToChucQuanLyService ToChucQuanLyService, IWebHostEnvironment WebHostEnvironment) : base(ToChucQuanLyService, WebHostEnvironment)
        {
            _ToChucQuanLyService = ToChucQuanLyService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

