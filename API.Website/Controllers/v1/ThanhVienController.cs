namespace API.Website.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThanhVienController : BaseController<ThanhVien, IThanhVienService>
    {
        private readonly IThanhVienService _ThanhVienService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ThanhVienController(IThanhVienService ThanhVienService

            , IWebHostEnvironment WebHostEnvironment

            ) : base(ThanhVienService, WebHostEnvironment)
        {
            _ThanhVienService = ThanhVienService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByIDAsync")]
        public virtual async Task<ThanhVien> GetByIDAsync()
        {
            ThanhVien result = new ThanhVien();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ThanhVienService.GetByIDAsync(model.ID);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                result.Note = message;
            }
            return result;
        }

    }
}

