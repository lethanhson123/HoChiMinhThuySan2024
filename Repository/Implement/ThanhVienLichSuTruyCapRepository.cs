namespace Repository.Implement
{
    public class ThanhVienLichSuTruyCapRepository : BaseRepository<ThanhVienLichSuTruyCap>
    , IThanhVienLichSuTruyCapRepository
    {
    private readonly Data.Context.Context _context;
    public ThanhVienLichSuTruyCapRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

