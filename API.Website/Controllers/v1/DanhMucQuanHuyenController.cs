namespace API.Website.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucQuanHuyenController : BaseController<DanhMucQuanHuyen, IDanhMucQuanHuyenService>
    {
        private readonly IDanhMucQuanHuyenService _DanhMucQuanHuyenService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucQuanHuyenController(IDanhMucQuanHuyenService DanhMucQuanHuyenService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucQuanHuyenService, WebHostEnvironment)
        {
            _DanhMucQuanHuyenService = DanhMucQuanHuyenService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetAllToListAsync")]
        public virtual async Task<List<DanhMucQuanHuyen>> GetAllToListAsync()
        {
            List<DanhMucQuanHuyen> result = new List<DanhMucQuanHuyen>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _DanhMucQuanHuyenService.GetAllToListAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}

