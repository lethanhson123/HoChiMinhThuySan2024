namespace Service.Implement
{
    public class ToChucTapTinDinhKemService : BaseService<ToChucTapTinDinhKem, IToChucTapTinDinhKemRepository>
    , IToChucTapTinDinhKemService
    {
    private readonly IToChucTapTinDinhKemRepository _ToChucTapTinDinhKemRepository;
    public ToChucTapTinDinhKemService(IToChucTapTinDinhKemRepository ToChucTapTinDinhKemRepository) : base(ToChucTapTinDinhKemRepository)
    {
    _ToChucTapTinDinhKemRepository = ToChucTapTinDinhKemRepository;
    }
    }
    }

