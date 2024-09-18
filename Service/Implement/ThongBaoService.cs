namespace Service.Implement
{
    public class ThongBaoService : BaseService<ThongBao, IThongBaoRepository>
    , IThongBaoService
    {
    private readonly IThongBaoRepository _ThongBaoRepository;
    public ThongBaoService(IThongBaoRepository ThongBaoRepository) : base(ThongBaoRepository)
    {
    _ThongBaoRepository = ThongBaoRepository;
    }
    }
    }

