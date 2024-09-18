namespace API.Report.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class ReportController : BaseController<Data.Model.Report, IReportService>
	{
		private readonly IReportService _ReportService;
		private readonly IWebHostEnvironment _WebHostEnvironment;
		
		public ReportController(IReportService ReportService, IWebHostEnvironment WebHostEnvironment) : base(ReportService, WebHostEnvironment)
		{
			_ReportService = ReportService;
			_WebHostEnvironment = WebHostEnvironment;			
		}
        [HttpPost]
        [Route("Report000012ToListAsync")]
        public async Task<List<Data.Model.Report>> Report000012ToListAsync()
        {
            List<Data.Model.Report> result = new List<Data.Model.Report>();
            try
            {
                BaseParameter model = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                result = await _ReportService.Report000012ToListAsync(model.ParentID.Value);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Report00003ToListAsync")]
        public async Task<List<Data.Model.Report>> Report00003ToListAsync()
        {
            List<Data.Model.Report> result = new List<Data.Model.Report>();
            try
            {                
                result = await _ReportService.Report00003ToListAsync();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

