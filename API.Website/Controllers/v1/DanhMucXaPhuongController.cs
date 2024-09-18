namespace API.Website.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucXaPhuongController : BaseController<DanhMucXaPhuong, IDanhMucXaPhuongService>
    {
        private readonly IDanhMucXaPhuongService _DanhMucXaPhuongService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucXaPhuongController(IDanhMucXaPhuongService DanhMucXaPhuongService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucXaPhuongService, WebHostEnvironment)
        {
            _DanhMucXaPhuongService = DanhMucXaPhuongService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByParentIDToListAsync")]
        public virtual async Task<List<DanhMucXaPhuong>> GetByParentIDToListAsync()
        {
            List<DanhMucXaPhuong> result = new List<DanhMucXaPhuong>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _DanhMucXaPhuongService.GetByParentIDToListAsync(model.ParentID.Value);
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

