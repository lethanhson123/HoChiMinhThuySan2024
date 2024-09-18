namespace Repository.Implement
{
    public class ToChucNguyenVatLieuRepository : BaseRepository<ToChucNguyenVatLieu>
    , IToChucNguyenVatLieuRepository
    {
    private readonly Data.Context.Context _context;
    public ToChucNguyenVatLieuRepository(Data.Context.Context context) : base(context)
    {
    _context = context;
    }
    }
    }

