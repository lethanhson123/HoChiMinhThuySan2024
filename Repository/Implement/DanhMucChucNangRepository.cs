namespace Repository.Implement
{
    public class DanhMucChucNangRepository : BaseRepository<DanhMucChucNang>
    , IDanhMucChucNangRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucChucNangRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

