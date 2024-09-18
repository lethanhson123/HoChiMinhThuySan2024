namespace API.Map.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucTinhThanhToaDoController : BaseController<DanhMucTinhThanhToaDo, IDanhMucTinhThanhToaDoService>
    {
        private readonly IDanhMucTinhThanhToaDoService _DanhMucTinhThanhToaDoService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucTinhThanhToaDoController(IDanhMucTinhThanhToaDoService DanhMucTinhThanhToaDoService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucTinhThanhToaDoService, WebHostEnvironment)
        {
            _DanhMucTinhThanhToaDoService = DanhMucTinhThanhToaDoService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetSQLDanhMucQuanHuyenByParentIDToListAsync")]
        public async Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucQuanHuyenByParentIDToListAsync()
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _DanhMucTinhThanhToaDoService.GetSQLDanhMucQuanHuyenByParentIDToListAsync(model.ParentID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLDanhMucXaPhuongByParentIDToListAsync")]
        public async Task<List<DanhMucTinhThanhToaDo>> GetSQLDanhMucXaPhuongByParentIDToListAsync()
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _DanhMucTinhThanhToaDoService.GetSQLDanhMucXaPhuongByParentIDToListAsync(model.ParentID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByParentIDToListAsync")]
        public async Task<List<DanhMucTinhThanhToaDo>> GetSQLByParentIDToListAsync()
        {
            List<DanhMucTinhThanhToaDo> result = new List<DanhMucTinhThanhToaDo>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _DanhMucTinhThanhToaDoService.GetSQLByParentIDToListAsync(model.ParentID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

