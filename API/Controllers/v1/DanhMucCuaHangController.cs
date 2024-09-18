using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucCuaHangController : BaseController<DanhMucCuaHang, IDanhMucCuaHangService>
    {
        private readonly IDanhMucCuaHangService _DanhMucCuaHangService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucCuaHangController(IDanhMucCuaHangService DanhMucCuaHangService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucCuaHangService, WebHostEnvironment)
        {
            _DanhMucCuaHangService = DanhMucCuaHangService;
            _WebHostEnvironment = WebHostEnvironment;
        }       
       
    }
}

