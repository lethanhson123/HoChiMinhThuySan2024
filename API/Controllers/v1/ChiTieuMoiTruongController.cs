namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ChiTieuMoiTruongController : BaseController<ChiTieuMoiTruong, IChiTieuMoiTruongService>
    {
        private readonly IChiTieuMoiTruongService _ChiTieuMoiTruongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ChiTieuMoiTruongController(IChiTieuMoiTruongService ChiTieuMoiTruongService, IWebHostEnvironment WebHostEnvironment) : base(ChiTieuMoiTruongService, WebHostEnvironment)
        {
            _ChiTieuMoiTruongService = ChiTieuMoiTruongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByBatDau_KetThucToListAsync")]
        public async Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucToListAsync()
        {
            List<ChiTieuMoiTruong> result = new List<ChiTieuMoiTruong>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ChiTieuMoiTruongService.GetByBatDau_KetThucToListAsync(model.BatDau.Value, model.KetThuc.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetByBatDau_KetThucAndEmptyToListAsync")]
        public async Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucAndEmptyToListAsync()
        {
            List<ChiTieuMoiTruong> result = new List<ChiTieuMoiTruong>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ChiTieuMoiTruongService.GetByBatDau_KetThucAndEmptyToListAsync(model.BatDau.Value, model.KetThuc.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

