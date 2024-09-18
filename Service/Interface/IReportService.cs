namespace Service.Interface
{
    public interface IReportService : IBaseService<Report>
    {
        Task<List<Report>> Report000012ToListAsync(long ParentID);
        Task<List<Report>> Report00003ToListAsync();
    }
}

