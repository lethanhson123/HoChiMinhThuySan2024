namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucVungNuoiController : BaseController<ToChucVungNuoi, IToChucVungNuoiService>
    {
        private readonly IToChucVungNuoiService _ToChucVungNuoiService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucVungNuoiController(IToChucVungNuoiService ToChucVungNuoiService, IWebHostEnvironment WebHostEnvironment) : base(ToChucVungNuoiService, WebHostEnvironment)
        {
            _ToChucVungNuoiService = ToChucVungNuoiService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

