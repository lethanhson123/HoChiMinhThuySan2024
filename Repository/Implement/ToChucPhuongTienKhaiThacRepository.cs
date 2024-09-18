namespace Repository.Implement
{
    public class ToChucPhuongTienKhaiThacRepository : BaseRepository<ToChucPhuongTienKhaiThac>
    , IToChucPhuongTienKhaiThacRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucPhuongTienKhaiThacRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

