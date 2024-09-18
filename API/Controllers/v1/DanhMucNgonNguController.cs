namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucNgonNguController : BaseController<DanhMucNgonNgu, IDanhMucNgonNguService>
    {
        private readonly IDanhMucNgonNguService _DanhMucNgonNguService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucNgonNguController(IDanhMucNgonNguService DanhMucNgonNguService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucNgonNguService, WebHostEnvironment)
        {
            _DanhMucNgonNguService = DanhMucNgonNguService;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

