namespace API.Controllers.v1
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

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllToListAnonymousAsync")]
        public async Task<List<ThanhVien>> GetAllToListAnonymousAsync()
        {
            List<ThanhVien> result = new List<ThanhVien>();
            try
            {
                result = await _ThanhVienService.GetAllToListAsync();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AuthenticationAsync")]
        public async Task<ThanhVien> AuthenticationAsync()
        {
            ThanhVien result = new ThanhVien();
            try
            {
                result = JsonConvert.DeserializeObject<ThanhVien>(Request.Form["data"]);
                result = await _ThanhVienService.AuthenticationAsync(result);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("GetByIDAndKeyAsync")]
        public async Task<ThanhVien> GetByIDAndKeyAsync()
        {
            ThanhVien result = new ThanhVien();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.TypeName == GlobalHelper.Key)
                {
                    result = await _ThanhVienService.GetByIDAsync(model.ID);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ChangePasswordAsync")]
        public async Task<ThanhVien> ChangePasswordAsync()
        {
            ThanhVien result = new ThanhVien();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ThanhVienService.ChangePasswordAsync(model.ThanhVien, model.Password01, model.Password02, model.Password03);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }


        [HttpPost]
        [Route("SaveSyncAsync")]
        public virtual async Task<ThanhVien> SaveSyncAsync()
        {
            ThanhVien result = new ThanhVien();
            try
            {
                result = JsonConvert.DeserializeObject<ThanhVien>(Request.Form["data"]);
                result = await _ThanhVienService.SaveSyncAsync(result);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                result.Note = message;
            }
            return result;
        }
        [HttpPost]
        [Route("SaveListSyncAsync")]
        public virtual async Task<List<ThanhVien>> SaveListSyncAsync()
        {
            List<ThanhVien> result = new List<ThanhVien>();
            try
            {
                List<ThanhVien> List = JsonConvert.DeserializeObject<List<ThanhVien>>(Request.Form["data"]);
                foreach (ThanhVien item in List)
                {
                    await _ThanhVienService.SaveSyncAsync(item);
                    result.Add(item);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("SyncFromToChucAsync")]
        public virtual async Task<List<ThanhVien>> SyncFromToChucAsync()
        {
            List<ThanhVien> result = new List<ThanhVien>();
            try
            {
                await _ThanhVienService.SyncFromToChucAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}

