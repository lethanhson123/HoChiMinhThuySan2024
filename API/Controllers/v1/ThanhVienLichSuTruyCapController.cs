namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThanhVienLichSuTruyCapController : BaseController<ThanhVienLichSuTruyCap, IThanhVienLichSuTruyCapService>
    {
        private readonly IThanhVienLichSuTruyCapService _ThanhVienLichSuTruyCapService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ThanhVienLichSuTruyCapController(IThanhVienLichSuTruyCapService ThanhVienLichSuTruyCapService, IWebHostEnvironment WebHostEnvironment) : base(ThanhVienLichSuTruyCapService, WebHostEnvironment)
        {
            _ThanhVienLichSuTruyCapService = ThanhVienLichSuTruyCapService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByBatDau_KetThucToListAsync")]
        public async Task<List<ThanhVienLichSuTruyCap>> GetByBatDau_KetThucToListAsync()
        {
            List<ThanhVienLichSuTruyCap> result = new List<ThanhVienLichSuTruyCap>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienLichSuTruyCapService.GetByBatDau_KetThucToListAsync(model.BatDau.Value, model.KetThuc.Value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetBySearchString_BatDau_KetThucToListAsync")]
        public async Task<List<ThanhVienLichSuTruyCap>> GetBySearchString_BatDau_KetThucToListAsync()
        {
            List<ThanhVienLichSuTruyCap> result = new List<ThanhVienLichSuTruyCap>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienLichSuTruyCapService.GetBySearchString_BatDau_KetThucToListAsync(model.SearchString, model.BatDau.Value, model.KetThuc.Value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}

