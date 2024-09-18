
namespace API.Upload.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController<T, TBaseService> : Controller
        where T : BaseModel
        where TBaseService : IBaseService<T>
    {
        private readonly TBaseService _BaseService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public BaseController(TBaseService baseService
            , IWebHostEnvironment WebHostEnvironment)
        {
            _BaseService = baseService;
            _WebHostEnvironment = WebHostEnvironment;
        }

    }
}
