namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucPhuongTienKhaiThacController : BaseController<ToChucPhuongTienKhaiThac, IToChucPhuongTienKhaiThacService>
    {
        private readonly IToChucPhuongTienKhaiThacService _ToChucPhuongTienKhaiThacService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucPhuongTienKhaiThacController(IToChucPhuongTienKhaiThacService ToChucPhuongTienKhaiThacService, IWebHostEnvironment WebHostEnvironment) : base(ToChucPhuongTienKhaiThacService, WebHostEnvironment)
        {
            _ToChucPhuongTienKhaiThacService = ToChucPhuongTienKhaiThacService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

