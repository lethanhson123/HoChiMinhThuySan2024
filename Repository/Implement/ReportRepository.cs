namespace Repository.Implement
{
    public class ReportRepository : BaseRepository<Report>
    , IReportRepository
    {
        private readonly Data.Context.Context _context;
        public ReportRepository(Data.Context.Context context) : base(context)
        {
            _context = context;
        }
    }
}

