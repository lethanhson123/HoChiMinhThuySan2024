namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucTieuChuanController : BaseController<ToChucTieuChuan, IToChucTieuChuanService>
    {
        private readonly IToChucTieuChuanService _ToChucTieuChuanService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucTieuChuanController(IToChucTieuChuanService ToChucTieuChuanService, IWebHostEnvironment WebHostEnvironment) : base(ToChucTieuChuanService, WebHostEnvironment)
        {
            _ToChucTieuChuanService = ToChucTieuChuanService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

