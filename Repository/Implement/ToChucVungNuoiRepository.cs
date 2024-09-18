namespace Repository.Implement
{
    public class ToChucVungNuoiRepository : BaseRepository<ToChucVungNuoi>
    , IToChucVungNuoiRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucVungNuoiRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

