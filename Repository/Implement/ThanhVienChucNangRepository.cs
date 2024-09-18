namespace Repository.Implement
{
    public class ThanhVienChucNangRepository : BaseRepository<ThanhVienChucNang>
    , IThanhVienChucNangRepository
    {
    private readonly Data.Context.Context _context;
    public ThanhVienChucNangRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

