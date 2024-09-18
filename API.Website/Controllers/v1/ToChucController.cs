namespace API.Website.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ToChucController : BaseController<ToChuc, IToChucService>
    {
        private readonly IToChucService _ToChucService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ToChucController(IToChucService ToChucService, IWebHostEnvironment WebHostEnvironment) : base(ToChucService, WebHostEnvironment)
        {
            _ToChucService = ToChucService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync")]
        public async Task<List<ToChuc>> GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync(model.ParentID.Value, model.SearchString, model.DanhMucQuanHuyenID.Value, model.DanhMucXaPhuongID.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByParentID_ActiveToListAsync")]
        public async Task<List<ToChuc>> GetSQLByParentID_ActiveToListAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetSQLByParentID_ActiveToListAsync(model.ParentID.Value, model.Active.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByParentID_Active_SearchStringToListAsync")]
        public async Task<List<ToChuc>> GetSQLByParentID_Active_SearchStringToListAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetSQLByParentID_Active_SearchStringToListAsync(model.ParentID.Value, model.Active.Value, model.SearchString);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync")]
        public async Task<List<ToChuc>> GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync(model.ParentID.Value, model.Active.Value, model.SearchString, model.DanhMucQuanHuyenID.Value, model.DanhMucXaPhuongID.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByDanhMucGiongIDToListAsync")]
        public async Task<List<ToChuc>> GetSQLByDanhMucGiongIDToListAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetSQLByDanhMucGiongIDToListAsync(model.DanhMucGiongID.Value);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetSQLByDanhMucGiongID_ActiveToListAsync")]
        public async Task<List<ToChuc>> GetSQLByDanhMucGiongID_ActiveToListAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (model.Token == GlobalHelper.TokenDefault)
                {
                    result = await _ToChucService.GetSQLByDanhMucGiongID_ActiveToListAsync(model.DanhMucGiongID.Value, model.Active.Value);
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

