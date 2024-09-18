using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucNguyenVatLieuController : BaseController<ToChucNguyenVatLieu, IToChucNguyenVatLieuService>
    {
        private readonly IToChucNguyenVatLieuService _ToChucNguyenVatLieuService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucNguyenVatLieuController(IToChucNguyenVatLieuService ToChucNguyenVatLieuService, IWebHostEnvironment WebHostEnvironment) : base(ToChucNguyenVatLieuService, WebHostEnvironment)
        {
            _ToChucNguyenVatLieuService = ToChucNguyenVatLieuService;
            _WebHostEnvironment = WebHostEnvironment;
        }       
    }
}

