namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThanhVienChucNangController : BaseController<ThanhVienChucNang, IThanhVienChucNangService>
    {
        private readonly IThanhVienChucNangService _ThanhVienChucNangService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ThanhVienChucNangController(IThanhVienChucNangService ThanhVienChucNangService, IWebHostEnvironment WebHostEnvironment) : base(ThanhVienChucNangService, WebHostEnvironment)
        {
            _ThanhVienChucNangService = ThanhVienChucNangService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetSQLByParentIDToListAsync")]
        public async Task<List<ThanhVienChucNang>> GetSQLByParentIDToListAsync()
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienChucNangService.GetSQLByParentIDToListAsync(model.ParentID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByDanhMucThanhVienIDToListAsync")]
        public async Task<List<ThanhVienChucNang>> GetSQLByDanhMucThanhVienIDToListAsync()
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienChucNangService.GetSQLByDanhMucThanhVienIDToListAsync(model.DanhMucThanhVienID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetByDanhMucChucNangIDAndEmptyToListAsync")]
        public async Task<List<ThanhVienChucNang>> GetByDanhMucChucNangIDAndEmptyToListAsync()
        {
            List<ThanhVienChucNang> result = new List<ThanhVienChucNang>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienChucNangService.GetByDanhMucChucNangIDAndEmptyToListAsync(model.DanhMucChucNangID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

