using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucNguyenVatLieuController : BaseController<DanhMucNguyenVatLieu, IDanhMucNguyenVatLieuService>
    {
        private readonly IDanhMucNguyenVatLieuService _DanhMucNguyenVatLieuService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucNguyenVatLieuController(IDanhMucNguyenVatLieuService DanhMucNguyenVatLieuService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucNguyenVatLieuService, WebHostEnvironment)
        {
            _DanhMucNguyenVatLieuService = DanhMucNguyenVatLieuService;
            _WebHostEnvironment = WebHostEnvironment;
        }     
    }
}

