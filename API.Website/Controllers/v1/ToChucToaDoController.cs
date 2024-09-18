namespace API.Website.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucToaDoController : BaseController<ToChucToaDo, IToChucToaDoService>
    {
        private readonly IToChucToaDoService _ToChucToaDoService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucToaDoController(IToChucToaDoService ToChucToaDoService, IWebHostEnvironment WebHostEnvironment) : base(ToChucToaDoService, WebHostEnvironment)
        {
            _ToChucToaDoService = ToChucToaDoService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByToChucVungNuoiIDToListAsync")]
        public async Task<List<ToChucToaDo>> GetByToChucVungNuoiIDToListAsync()
        {
            List<ToChucToaDo> result = new List<ToChucToaDo>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucToaDoService.GetByToChucVungNuoiIDToListAsync(model.ToChucVungNuoiID.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetByToChucVungNuoiIDAndEmptyToListAsync")]
        public async Task<List<ToChucToaDo>> GetByToChucVungNuoiIDAndEmptyToListAsync()
        {
            List<ToChucToaDo> result = new List<ToChucToaDo>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucToaDoService.GetByToChucVungNuoiIDAndEmptyToListAsync(model.ToChucVungNuoiID.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

