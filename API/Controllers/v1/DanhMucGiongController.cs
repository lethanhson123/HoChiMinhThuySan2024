namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucGiongController : BaseController<DanhMucGiong, IDanhMucGiongService>
    {
        private readonly IDanhMucGiongService _DanhMucGiongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucGiongController(IDanhMucGiongService DanhMucGiongService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucGiongService, WebHostEnvironment)
        {
            _DanhMucGiongService = DanhMucGiongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

