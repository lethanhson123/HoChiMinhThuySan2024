namespace Service.Implement
{
    public class ReportService : BaseService<Report, IReportRepository>
    , IReportService
    {
        private readonly IReportRepository _ReportRepository;
        public ReportService(IReportRepository ReportRepository) : base(ReportRepository)
        {
            _ReportRepository = ReportRepository;
        }
        public virtual async Task<List<Report>> Report00001ToListAsync(long ParentID)
        {
            List<Report> result = new List<Report>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                            new SqlParameter("@ParentID",ParentID),
                };
                result = await GetByStoredProcedureToListAsync("sp_Report00001", parameters);
            }
            return result;
        }
        public virtual async Task<List<Report>> Report00002ToListAsync(long ParentID)
        {
            List<Report> result = new List<Report>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                            new SqlParameter("@ParentID",ParentID),
                };
                result = await GetByStoredProcedureToListAsync("sp_Report00002", parameters);
            }
            return result;
        }
        public virtual async Task<List<Report>> Report000012ToListAsync(long ParentID)
        {
            List<Report> result = new List<Report>();
            if (ParentID > 0)
            {
                result = await Report00001ToListAsync(ParentID);
            }
            else
            {
                ParentID = GlobalHelper.DanhMucTinhThanhID;
                result = await Report00002ToListAsync(ParentID);
            }

            return result;
        }
        public virtual async Task<List<Report>> Report00003ToListAsync()
        {
            List<Report> result = new List<Report>();
            result = await GetByStoredProcedureToListAsync("sp_Report00003");
            return result;
        }
    }
}

