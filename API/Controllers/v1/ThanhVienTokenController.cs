namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ThanhVienTokenController : BaseController<ThanhVienToken, IThanhVienTokenService>
    {
        private readonly IThanhVienTokenService _ThanhVienTokenService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ThanhVienTokenController(IThanhVienTokenService ThanhVienTokenService, IWebHostEnvironment WebHostEnvironment) : base(ThanhVienTokenService, WebHostEnvironment)
        {
            _ThanhVienTokenService = ThanhVienTokenService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AuthenticationByTokenAsync")]
        public virtual async Task<ThanhVienToken> AuthenticationByTokenAsync()
        {
            ThanhVienToken result = new ThanhVienToken();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienTokenService.AuthenticationByTokenAsync(model.Token);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

