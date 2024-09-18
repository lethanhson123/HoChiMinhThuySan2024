namespace Repository.Implement
{
    public class DanhMucXaPhuongRepository : BaseRepository<DanhMucXaPhuong>
    , IDanhMucXaPhuongRepository
    {
    private readonly Data.Context.Context _context;
    public DanhMucXaPhuongRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

