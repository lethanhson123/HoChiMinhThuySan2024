namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucGiongController : BaseController<ToChucGiong, IToChucGiongService>
    {
        private readonly IToChucGiongService _ToChucGiongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucGiongController(IToChucGiongService ToChucGiongService, IWebHostEnvironment WebHostEnvironment) : base(ToChucGiongService, WebHostEnvironment)
        {
            _ToChucGiongService = ToChucGiongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

